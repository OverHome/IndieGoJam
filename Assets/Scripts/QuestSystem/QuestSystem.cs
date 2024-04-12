using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSystem: MonoBehaviour
{
    public static QuestSystem Instance;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private List<Quest> quests;
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

        SetQuest(0);
        
    }

    private void SetQuest(int id)
    {
        nameText.text = quests[id].Name;
        descriptionText.text = quests[id].Descruption;
        _questId = id;
    }

    public void NextQuest()
    {
        SetQuest(_questId + 1);
    }

    public int GetQuestId()
    {
        return quests[_questId].Id;
    }
}
