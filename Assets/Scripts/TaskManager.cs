using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public GameObject HomeWarning;
    public GameObject BankScreen;
    public GameObject GalleryScreen;

    bool homeScreen = false;
    bool bankScreen = false;
    //bool gallery = false;

    public void HomeButton()
    {
        if (!homeScreen) {
            homeScreen = true;
            HomeWarning.SetActive(true);
        }
        else
        {
           homeScreen = false;
            HomeWarning.SetActive(false);
        }
    }

    public void bankButton()
    {
        if (!bankScreen)
        {
            bankScreen = true;
            BankScreen.SetActive(true);
        }
        else
        {
            bankScreen = false;
            BankScreen.SetActive(false);
        }
    }

    //public void toggleGallery()
    //{
    //    if (!gallery)
    //    {
    //        gallery = true;
    //        GalleryScreen.SetActive(true);
    //    }
    //    else
    //    {
    //        gallery = false;
    //        GalleryScreen.SetActive(false);
    //    }
    //}


}
