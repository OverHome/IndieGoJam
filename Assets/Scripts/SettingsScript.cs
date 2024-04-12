using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private Resolution[] _resolution;
    private String[] _qualityPreset = {"Низкие","Средние","По ГОСТу"};
    private String[] _FSRquality = {"Выкл","Качество","Баланс","Производительность"};
    public TextMeshProUGUI resText;
    public TextMeshProUGUI qualityText;
    public TextMeshProUGUI FSRText;
    public Slider volumeSlider;
    void Start(){
        _resolution = Screen.resolutions;
        resText.text = Screen.currentResolution.width.ToString() + "X" + Screen.currentResolution.height.ToString();
        qualityText.text = _qualityPreset[2];
        FSRText.text = _FSRquality[0];
        volumeSlider.value = AudioListener.volume;
    }
    public void changeVolume(){
        AudioListener.volume = (float) volumeSlider.value;
    }
    public void ChangeValueLeft(int type){
        switch(type){
            case 0:
            print(Screen.currentResolution);
                for(int i = _resolution.Length-1; i >= 0; i--){
                    if(Screen.currentResolution.height * Screen.currentResolution.width > _resolution[i].height * _resolution[i].width && Is16By9(_resolution[i].width,_resolution[i].height)){
                        Screen.SetResolution(_resolution[i].width,_resolution[i].height,true);
                        resText.text = _resolution[i].width.ToString() + "X" + _resolution[i].height.ToString();
                        break;
                    }
                }
            break;
        }
    }
    public void ChangeValueRight(int type){
        switch(type){
            case 0:
            print(Screen.currentResolution);
                for(int i = 0; i < _resolution.Length; i++){
                    if(Screen.currentResolution.height * Screen.currentResolution.width < _resolution[i].height * _resolution[i].width && Is16By9(_resolution[i].width,_resolution[i].height)){
                        Screen.SetResolution(_resolution[i].width,_resolution[i].height,true);
                        resText.text = _resolution[i].width.ToString() + "X" + _resolution[i].height.ToString();
                        break;
                    }
                }
            break;
        }
    }
    bool Is16By9(int width, int height)
    {
        float aspectRatio = (float)width / height;
        return Mathf.Approximately(aspectRatio, 16f / 9f);
    }
}
