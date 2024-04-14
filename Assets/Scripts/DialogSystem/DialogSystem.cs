using System.Collections;
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

    private Coroutine play;
    private void Start()
    {
        QuestSystem.Instance.OnChangeQuest.AddListener(TryPlay);
        TryPlay(QuestSystem.Instance.GetQuestId());
    }

    private void TryPlay(int id)
    {
        if(play != null) StopCoroutine(play);
        foreach (var dialoge in dialoges)
        {
            if (dialoge.Quest.Id == id)
            {
                subText.enabled = true;
                audioSource.enabled = true;
                
                play = StartCoroutine(PlayAnudio(dialoge.Data));
                break;
            }
        }
    }

    private IEnumerator PlayAnudio(DialogeData data)
    {
        foreach (var says in data.Data)
        {
            subText.text = says.Sub;
            audioSource.clip = says.Audio;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        subText.enabled = false;
        audioSource.enabled = false;
    }
}
