using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour{
    public void scenLoad(int scenNum){
        SceneManager.LoadScene(scenNum);
    }
}