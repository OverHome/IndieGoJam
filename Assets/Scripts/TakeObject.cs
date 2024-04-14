using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private Transform objPos;
    [SerializeField] private PlayerController playerController;
    public float maxDistance = 1f;

    private Rigidbody takedObj;
    private bool _isTaked;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
            
            RaycastHit hitInfo;
            bool isRay = Physics.Raycast(ray, out hitInfo, maxDistance);
            
            if (!_isTaked)
            {
                if (!isRay) return;
                if (!hitInfo.transform.gameObject.CompareTag("Takeable")) return;
                hitInfo.rigidbody.isKinematic = true;
                hitInfo.collider.enabled = false;
                hitInfo.transform.parent = objPos;
                hitInfo.transform.position = objPos.position;
                hitInfo.transform.rotation = objPos.rotation;
                if (hitInfo.collider.GetComponent<Prop>().itemId == 1)
                    hitInfo.transform.localPosition += new Vector3(-2, 0, 0);
                takedObj = hitInfo.transform.GetComponent<Rigidbody>();
                hitInfo.transform.GetComponent<TakeTriger>()?.Trigger();
                _isTaked = true;
                animator.SetBool("IsTake", true);
            }
            else
            {
                if(isRay && hitInfo.transform != null && hitInfo.transform.gameObject.CompareTag("Used"))
                {
                    if (hitInfo.transform.GetComponent<UseItemTrigger>()?.needItemUI == takedObj.GetComponent<Prop>()?.itemId)
                    {
                        if (hitInfo.transform.GetComponent<UseItemTrigger>().Trigger())
                        {
                            _isTaked = false;
                            takedObj.transform.parent = hitInfo.transform;
                            takedObj.transform.rotation = new Quaternion(0, 0, 0, 0);
                            takedObj.transform.localPosition = new Vector3(0, 0 ,0 );
                            takedObj = null;
                            animator.SetBool("IsTake", false);
                        }
                        else
                        {
                            print("Не сейчас");
                        }
                    }
                    else
                    {
                        print("Не тот предмет");
                    }
                }
                else
                {
                    _isTaked = false;
                    takedObj.transform.parent = null;
                    takedObj.isKinematic = false;
                    takedObj.GetComponent<Collider>().enabled = true;
                    takedObj.AddForce((Camera.main.transform.forward + playerController.GetForse())*4, ForceMode.Force);
                    takedObj = null;
                    animator.SetBool("IsTake", false);
                }
            }
        }
    }
}
