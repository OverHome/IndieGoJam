using UnityEngine;


public class MiniGame : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected bool _isGameStart;
    protected InteractWithGame _interactor;

    public virtual void StartGame(InteractWithGame interactor)
    {
        _interactor = interactor;
        _isGameStart = true;
        animator.gameObject.SetActive(true);
    }
    

    public void StopGame()
    {
        _isGameStart = false;
        _interactor.StopGame();
        animator.gameObject.SetActive(false);
    }
  
}
