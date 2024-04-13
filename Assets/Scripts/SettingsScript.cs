using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    // Unity Settings Lists
    private Resolution[] _resolution;
    public UniversalRenderPipelineAsset[] pipleLineRender;
    public UnityEngine.ShadowResolution[] shadowResolutionsArray = {UnityEngine.ShadowResolution.Low,UnityEngine.ShadowResolution.Medium,UnityEngine.ShadowResolution.VeryHigh};
    // TEXT
    private String[] _qualityPreset = {"Низкие","Средние","По ГОСТу"};
    private String[] _FSRquality = {"Выкл","Качество","Баланс","Производительность"};

    // VARIABLES
    private int _currentQuality;
    public TextMeshProUGUI resText;
    public TextMeshProUGUI qualityText;
    public TextMeshProUGUI FSRText;
    public Slider volumeSlider;
    void Start(){
        _resolution = Screen.resolutions;
        resText.text = Screen.currentResolution.width.ToString() + "X" + Screen.currentResolution.height.ToString();
        qualityText.text = _qualityPreset[2];
        _currentQuality = 2;
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
            case 1:
                if(_currentQuality != 0){
                    _currentQuality -= 1;
                    QualitySettings.SetQualityLevel(_currentQuality,true);
                    print(GraphicsSettings.renderPipelineAsset);
                    print(QualitySettings.shadowResolution);
                    qualityText.text = _qualityPreset[_currentQuality];
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
            case 1:
                if(_currentQuality != pipleLineRender.Length - 1){
                    _currentQuality += 1;
                    QualitySettings.SetQualityLevel(_currentQuality,true);
                    print(GraphicsSettings.renderPipelineAsset);
                    print(QualitySettings.shadowResolution);
                    qualityText.text = _qualityPreset[_currentQuality];
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
