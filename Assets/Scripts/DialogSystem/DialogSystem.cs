using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<Dialoge> dialoges;
    
    private void Start()
    {
        QuestSystem.Instance.OnChangeQuest.AddListener(TryPlay);
        TryPlay(QuestSystem.Instance.GetQuestId());
    }

    private void TryPlay(int id)
    {
        foreach (var dialoge in dialoges)
        {
            if (dialoge.Quest.Id == id)
            {
                subText.enabled = true;
                audioSource.enabled = true;
                subText.text = dialoge.Data.Data[0].Sub;
                audioSource.clip = dialoge.Data.Data[0].Audio;
                audioSource.Play();
                break;
            }
        }
    }
}
