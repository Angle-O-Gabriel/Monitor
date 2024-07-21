using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] public QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishpoint = true;

    //private string questId;
    private QuestState currentQuestState;

    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    public void onStartQuest()
    {
        if(currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.Instance.questEvents.StartQuest(questInfoForPoint.id);
        }
        else if(currentQuestState.Equals(QuestState.CAN_FINISH) && finishpoint)
        {
            Debug.Log("button to finish quest pressed");
            GameEventsManager.Instance.questEvents.FinishQuest(questInfoForPoint.id);
        }
    }

    private void QuestStateChange(Quest quest)
    {
        //only update the quest state if this point has the corresponding quest
        if(quest.info.id.Equals(questInfoForPoint.id))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest with id: " + questInfoForPoint.id + "updated to state: " + currentQuestState);
        }

    }
}
