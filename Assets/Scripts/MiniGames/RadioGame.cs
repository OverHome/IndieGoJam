
using System;
using UnityEngine;

public class RadioGame: MiniGame
{
    [SerializeField] private GameObject knob;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float needRotate = 100;

    private float _tempRotate;
    private void Update()
    {
        if (_isGameStart)
        {
            var a = Input.GetKey(KeyCode.A);
            var d = Input.GetKey(KeyCode.D);
            if(a==d) return;

            if (a)
            {
                knob.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
            else if (d)
            {
                knob.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
            }

            _tempRotate += rotationSpeed * Time.deltaTime;
            if (_tempRotate >= needRotate)
            {
                StopGame();
            }
        }
    }
}
