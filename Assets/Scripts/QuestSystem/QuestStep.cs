using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;

    protected void FinishQuestStep()
    {
        if(!isFinished)
        {
            isFinished = true;

            // TO-D0 : Advance the quest forwards now that we've finished this step

            Destroy(this.gameObject);
        }
    }
}
