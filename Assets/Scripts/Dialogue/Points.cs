using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] public Vector3[] markers;
    [SerializeField] public bool IsRepeatable;

    public Vector3 GetMarker(int marker)
    {
        return markers[marker];
    }

    public int GetSize()
    {
        return markers.Length;
    }

    public bool IsThisRepeatable()
    {
        return IsRepeatable;
    }

}
