using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiscEvents
{
    public event Action onTakePicture;

    public void TakePicture()
    {
        if (onTakePicture != null)
        {
            onTakePicture();
        }
    }

    public event Action OnPictureTaken;
    public void PictureTook()
    {
        if (OnPictureTaken != null)
        {
            OnPictureTaken();
        }
    }
}
