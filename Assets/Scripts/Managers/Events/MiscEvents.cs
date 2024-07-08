using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscEvents
{
    public event Action OnPictureTaken;

    public void PictureTook()
    {
        if (OnPictureTaken != null)
        {
            OnPictureTaken();
        }
    }
}
