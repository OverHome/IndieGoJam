using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private Transform objPos;
    [SerializeField] private PlayerController playerController;
    public float maxDistance = 1f;

    private Rigidbody takedObj;
    private bool _isTaked;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isTaked)
            {
                Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
            
                RaycastHit hitInfo;

                if (!Physics.Raycast(ray, out hitInfo, maxDistance)) return;
                if (!hitInfo.transform.gameObject.CompareTag("Takeable")) return;
                hitInfo.rigidbody.isKinematic = true;
                hitInfo.collider.enabled = false;
                hitInfo.transform.parent = objPos;
                hitInfo.transform.position = objPos.position;
                takedObj = hitInfo.transform.GetComponent<Rigidbody>();
                _isTaked = true;
            }
            else
            {
                _isTaked = false;
                takedObj.transform.parent = null;
                takedObj.isKinematic = false;
                takedObj.GetComponent<Collider>().enabled = true;
                takedObj.AddForce((Camera.main.transform.forward + playerController.GetForse())*4, ForceMode.Force);
                print( playerController.GetForse());
                takedObj = null;
            }
           
        }
    }
}
