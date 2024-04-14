using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestSystem: MonoBehaviour
{
    public static QuestSystem Instance;
    public UnityEvent<int> OnChangeQuest;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private List<Quest> quests;
    [SerializeField] private AudioSource audioSourse;
    private int _questId;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            print("QuestSystem already exist!!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetQuest(0);
    }

    private void SetQuest(int id)
    {
        nameText.text = quests[id].Name;
        descriptionText.text = quests[id].Descruption;
        _questId = id;
        OnChangeQuest.Invoke(quests[id].Id);
    }

    public void NextQuest()
    {
        SetQuest(_questId + 1);
        audioSourse.PlayOneShot(audioSourse.clip);
    }

    public int GetQuestId()
    {
        return quests[_questId].Id;
    }
}
