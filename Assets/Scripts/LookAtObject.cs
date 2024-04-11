using UnityEngine;
using UnityEngine.UI;

public class LookAtOutline : MonoBehaviour
{
    [SerializeField] private Image cursor;
    public float maxDistance = 10f; // Максимальная дистанция, на которой происходит проверка
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
        
    }
}