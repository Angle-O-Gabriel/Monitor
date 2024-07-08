using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePictureQuest : QuestStep
{
    private int picturesTook = 0;

    private int picturesToTake = 3;


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
        if(picturesTook < picturesToTake)
        {
            picturesTook++;
        }

        if(picturesTook >= picturesToTake)
        {
            FinishQuestStep();
        }
    }
}
