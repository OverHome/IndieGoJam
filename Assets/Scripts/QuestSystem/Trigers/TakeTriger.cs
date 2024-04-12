using UnityEngine;

public class TakeTriger : MonoBehaviour
{
    [SerializeField] private Quest quest;
    public void Trigger()
    {
        if (QuestSystem.Instance.GetQuestId() == quest.Id)
        {
            QuestSystem.Instance.NextQuest();
        }
       
    }
}
