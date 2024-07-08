using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_UI : MonoBehaviour
{

    public GameObject EmailPanel;
    public GameObject GalleryPanel;
    // Start is called before the first frame update
    public void LoadGallery()
    {
        GalleryPanel.SetActive(true);
    }

    public void LoadEmail()
    {
        EmailPanel.SetActive(true); 
    }
}
