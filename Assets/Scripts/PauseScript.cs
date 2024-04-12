using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour{
    public GameObject pauseMenuUI;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePauseMenu();
        }
    }
    public void TogglePauseMenu(){
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        if(pauseMenuUI.activeSelf == true){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}