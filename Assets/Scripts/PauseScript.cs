using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour{
    public GameObject pauseMenuUI;
    public GameObject settingUI;
    public GameObject developersUI;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePauseMenu();
        }
    }
    public void TogglePauseMenu(){
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        if(pauseMenuUI.activeSelf){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            if(settingUI.activeSelf){
                settingUI.SetActive(!settingUI.activeSelf);
            }
            if(developersUI.activeSelf){
                developersUI.SetActive(!developersUI.activeSelf);
            }
        }
    }
    public void setTimeGo(){
        Time.timeScale = 1;
    }
    public void changeActive(int obj){
        switch (obj)
        {
            case 0: // settings
                settingUI.SetActive(!settingUI.activeSelf);
                break;
            case 1: // developers 
                developersUI.SetActive(!developersUI.activeSelf);
                break;
        }
    }
}