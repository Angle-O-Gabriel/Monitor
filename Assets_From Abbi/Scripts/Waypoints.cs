using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<Waypoints> adjacentWaypoints;  // List of waypoints adjacent to this one

    // Start is called before the first frame update
    void Start()
    {
        // Hide the waypoint at the start
        SetVisible(false);
    }

    // Set the visibility of the waypoint
    public void SetVisible(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    // Reveal adjacent waypoints
    public void RevealAdjacentWaypoints()
    {
        foreach (Waypoints waypoint in adjacentWaypoints)
        {
            waypoint.SetVisible(true);
        }
    }
}
