using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [Header("Task - Panel")]
    [SerializeField] GameObject taskPanel;
    [SerializeField] LeanTweenType easeType;
    public bool taskPanelisOpen = false;

    public void toggleTaskPanel()
    {
        if (!taskPanelisOpen)
        {
            taskPanelisOpen = true;
            LeanTween.moveX(taskPanel, 1665f, 0.5f).setEase(easeType);
        }
        else
        {
            taskPanelisOpen = false;
            LeanTween.moveX(taskPanel, 2170f, 0.5f).setEase(easeType);
        }
    }

    public void toggleQuestionMark()
    {
        Debug.Log("TANONG KA JAN");
    }
}
