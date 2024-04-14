
using System;
using UnityEngine;

public class RadioGame: MiniGame
{
    [SerializeField] private GameObject knob;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Quest quest;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float needRotate = 100;

    private float _tempRotate;
    private void Update()
    {
        if (_isGameStart)
        {
            var a = Input.GetKey(KeyCode.A);
            var d = Input.GetKey(KeyCode.D);
            if (a == d)
            {
                animator.SetBool("ATrigger", false);
                animator.SetBool("BTrigger", false);
                return;
            };

            if (a)
            {
                knob.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
                arrow.transform.Rotate(rotationSpeed/3 * Time.deltaTime, 0, 0);
                animator.SetBool("ATrigger", true);
                animator.SetBool("BTrigger", false);
            }
            else if (d)
            {
                knob.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
                arrow.transform.Rotate(-rotationSpeed/3 * Time.deltaTime, 0, 0);
                animator.SetBool("BTrigger", true);
                animator.SetBool("ATrigger", false);
            }

            _tempRotate += rotationSpeed * Time.deltaTime;
            if (_tempRotate >= needRotate)
            {
                StopGame();
                QuestSystem.Instance.NextQuest();       
            }
        }
    }
}
