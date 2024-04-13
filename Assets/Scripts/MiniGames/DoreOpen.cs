using UnityEngine;

public class DoreOpen : MiniGame
{
    [SerializeField] private GameObject dore;
    [SerializeField] private Quest quest;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float needRotate = 100;

    private float _tempRotate;
    private void Update()
    {
        if (_isGameStart && QuestSystem.Instance.GetQuestId() == quest.Id)
        {
            var w = Input.GetKey(KeyCode.W);
            var space = Input.GetKeyDown(KeyCode.Space);

            if (w && space)
            {
                dore.transform.Rotate(0,-rotationSpeed * Time.deltaTime,  0);
                _tempRotate += rotationSpeed * Time.deltaTime;
            }
            if (_tempRotate >= needRotate)
            {
                StopGame();
                QuestSystem.Instance.NextQuest();       
            }
        }
    }
}
