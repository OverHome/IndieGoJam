using UnityEngine;

public class DoreOpen : MiniGame
{
    [SerializeField] private GameObject dore;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float needRotate = 100;

    private float _tempRotate;
    private void Update()
    {
        if (_isGameStart)
        {
            var space = Input.GetKeyDown(KeyCode.Space);

            if (space)
            {
                dore.transform.Rotate(rotationSpeed,0,  0);
                _tempRotate += rotationSpeed;
            }
            if (_tempRotate >= needRotate)
            {
                StopGame();
                QuestSystem.Instance.NextQuest();       
            }
        }
    }
}
