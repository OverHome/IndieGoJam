
using UnityEngine;

public class UseItemTrigger: MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] public int needItemUI;
    
    public bool Trigger()
    {
        if (QuestSystem.Instance.GetQuestId() == quest.Id)
        {
            QuestSystem.Instance.NextQuest();
            return true;
        }

        return false;
    }
}
