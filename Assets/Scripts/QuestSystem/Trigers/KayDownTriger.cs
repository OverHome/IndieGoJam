using System;
using UnityEngine;

public class KeyDownTriger : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private string pushKey;

    private void Update()
    {
        if (Input.GetKeyDown(pushKey))
        {
            Trigger();
        }
    }

    private void Trigger()
    {
        if (QuestSystem.Instance.GetQuestId() == quest.Id)
        {
            QuestSystem.Instance.NextQuest();
        }
    }
}
