using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;

    private string questId;

    public void InitializeQuestStep(string  questId)
    {
        this.questId = questId;
    }
    protected void FinishQuestStep()
    {
        if(!isFinished)
        {
            isFinished = true;
            GameEventsManager.Instance.questEvents.AdvanceQuest(questId);
            Debug.Log("Advanced Quest");
            Destroy(this.gameObject);
        }
    }
}
