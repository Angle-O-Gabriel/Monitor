using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PCScript : MonoBehaviour
{
    public GameObject UI;
    void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogError("No Collider found on this GameObject.");
        }
    }

    private void OnMouseDown()
    {
        UI.SetActive(true);
    }
}
