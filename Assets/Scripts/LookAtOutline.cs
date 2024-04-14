using UnityEngine;
using UnityEngine.UI;

public class LookAtOutline : MonoBehaviour
{
    [SerializeField] private Image takeImg;
    [SerializeField] private Image gameImg;
    public float maxDistance = 1f; // Максимальная дистанция, на которой происходит проверка
    private Outline lastOutline; // Последний объект с компонентом Outline

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Outline outline = hit.collider.gameObject.GetComponent<Outline>();
            
            if (outline != null)
            {
                if (outline != lastOutline)
                {
                    if (lastOutline != null)
                    {
                        lastOutline.enabled = false;
                       
                    }
                    outline.enabled = true;
                    // cursor.enabled = true;
                    lastOutline = outline;
                }
            }
            else
            {
                if (lastOutline != null)
                {
                    lastOutline.enabled = false;
                    // cursor.enabled = false;
                    lastOutline = null;
                }
            }

            if (hit.collider.CompareTag("MiniGame")&& hit.collider.GetComponent<MiniGame>().quest.Id == QuestSystem.Instance.GetQuestId() && !hit.collider.GetComponent<MiniGame>().IsStarted())
            {
                gameImg.gameObject.SetActive(true);
            }
            else if (hit.collider.CompareTag("Takeable"))
            {
                takeImg.gameObject.SetActive(true);
            }
            else
            {
                gameImg.gameObject.SetActive(false);
                takeImg.gameObject.SetActive(false);
            }
        }
        else
        {
          
            if (lastOutline != null)
            {
                gameImg.gameObject.SetActive(false);
                takeImg.gameObject.SetActive(false);
                lastOutline.enabled = false; 
                // cursor.enabled = false;
                lastOutline = null;
            }
        }
        
    }
}