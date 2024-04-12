using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour{
    public void scenLoad(int scenNum){
        SceneManager.LoadScene(scenNum);
        Time.timeScale = 1;
    }
    public void Exit(){
        
        Application.Quit();
    }
}