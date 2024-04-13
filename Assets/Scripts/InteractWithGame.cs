using System;
using UnityEngine;

public class InteractWithGame : MonoBehaviour
{
    [SerializeField] private float maxDistance = 1.7f;

    private PlayerController playerController;
    private MiniGame _miniGame;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void TryPlayGame()
    {
        if (_miniGame != null)
        {
            StopGame();
        }
        else
        {
            Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
            RaycastHit hitInfo;
            bool isRay = Physics.Raycast(ray, out hitInfo, maxDistance);
            if (!hitInfo.transform.gameObject.CompareTag("MiniGame")) return;

            _miniGame = hitInfo.transform.GetComponent<MiniGame>();
            playerController.SetMove(false);
            _miniGame.StartGame(this);
        }
      
    }

    public void StopGame()
    {
        playerController.SetMove(true);
        _miniGame = null;
    }
}
