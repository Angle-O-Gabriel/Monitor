using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundQuest : QuestStep
{
    private int stepsTaken = 0;

    private int stepsToTake = 2;


    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.OnPictureTaken += PictureTaken;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.miscEvents.OnPictureTaken -= PictureTaken;
    }

    private void PictureTaken()
    {
        if (stepsTaken < stepsToTake)
        {
            stepsTaken++;
        }

        if (stepsTaken >= stepsToTake)
        {
            FinishQuestStep();
        }
    }
}
