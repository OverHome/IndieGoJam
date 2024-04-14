using DG.Tweening;
using UnityEngine;

public class DoreOpen : MiniGame
{
    [SerializeField] private GameObject dore;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float needRotate = 100;

    private float _tempRotate;
    private void Update()
    {
        if (_isGameStart)
        {
            var space = Input.GetKeyDown(KeyCode.Space);

            if (space)
            {
                _tempRotate += rotationSpeed;
                var a = new Vector3(_tempRotate, 0, 0);
                dore.transform.DOLocalRotate(a, 0.2f);
            }
            if (_tempRotate >= needRotate)
            {
                StopGame();
                QuestSystem.Instance.NextQuest();       
            }
        }
    }
}
