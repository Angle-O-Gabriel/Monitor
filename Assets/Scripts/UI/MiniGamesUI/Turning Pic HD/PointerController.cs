using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform safeZone;
    public float moveSpeed = 100f;

    private float dir = 1f;
    private RectTransform pointerTransform;
    private Vector3 targetPos;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPos = pointB.position;
    }
    void Update()
    {
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position,
            targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPos = pointB.position;
            dir = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPos = pointA.position;
            dir = -1f;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
    }


    void CheckSuccess()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null)) 
        {
            Debug.Log("Success!");
        
        }
        else
        {
            Debug.Log("NYENYE!");
        }
    }
}