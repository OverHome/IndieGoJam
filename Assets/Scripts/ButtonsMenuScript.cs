using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor.Rendering.Universal;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;
    private Color hoverColor = new Color(0.98f, 0.96f, 0.82f, 1f); // Цвет FAF4D2
    public Button button;
    private Image buttonImage;
    public TMP_FontAsset fontNew;
    private TMP_FontAsset fontOld;

    void Start(){
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonImage = button.GetComponent<Image>();
        fontOld = buttonText.font;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = new Color(0.6f,0.176f,0.050f,1f);
        buttonText.font = fontNew;
        buttonImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
        buttonText.font = fontOld;
        buttonImage.color = new Color(0f,0f,0f,0f);
    }
    void OnDisable(){
        buttonText.color = hoverColor;
        buttonText.font = fontOld;
        buttonImage.color = new Color(0f,0f,0f,0f);
    }
}