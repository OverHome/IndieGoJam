using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour{
    public void scenLoad(int scenNum){
        SceneManager.LoadScene(scenNum);
    }
    public void Exit(){
        
        Application.Quit();
    }
}