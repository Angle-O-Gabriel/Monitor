using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementBasic : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    Transform NextPos;
    int nextPosIndex;
    [SerializeField] float MoveSpeed;
    [SerializeField] float mouseCooldown;
    private float lastClickTime = 0f;


    void Start()
    {
        NextPos = Positions[0];
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastClickTime >= mouseCooldown)
        {
            lastClickTime = Time.time;
            MoveGameObj();
            Debug.Log("Positions: " + transform.position.x + transform.position.y + transform.position.x);
        }

    }

    void MoveGameObj()
    {

        if (transform.position == NextPos.position)
        {
            nextPosIndex++;
            if (nextPosIndex >= Positions.Length)
            {
                nextPosIndex = 0;
            }
            NextPos = Positions[nextPosIndex];

        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, MoveSpeed * Time.deltaTime);
        }
    }
    //public Transform waypointsParent;  // The parent object containing all waypoints
    //public LayerMask groundLayer;      // Layer mask to ensure the raycast only hits the ground
    //private List<Transform> waypoints; // List to store all waypoints

    //void Start()
    //{
    //    // Initialize the waypoints list and populate it with child waypoints
    //    waypoints = new List<Transform>();
    //    foreach (Transform waypoint in waypointsParent)
    //    {
    //        waypoints.Add(waypoint);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Check if the left mouse button was clicked
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // Create a ray from the camera to the mouse position
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        // Perform the raycast only on the specified ground layer
    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
    //        {
    //            // Find the nearest waypoint to the click position
    //            Transform nearestWaypoint = FindNearestWaypoint(hit.point);

    //            // Move the player to the nearest waypoint
    //            if (nearestWaypoint != null)
    //            {
    //                // Move the player to the world position of the nearest waypoint
    //                transform.position = nearestWaypoint.position;
    //            }
    //        }
    //    }
    //}

    //// Find the nearest waypoint to a given position
    //Transform FindNearestWaypoint(Vector3 clickPosition)
    //{
    //    Transform nearestWaypoint = null;
    //    float minDistance = Mathf.Infinity;

    //    foreach (Transform waypoint in waypoints)
    //    {
    //        float distance = Vector3.Distance(clickPosition, waypoint.position);
    //        if (distance < minDistance)
    //        {
    //            minDistance = distance;
    //            nearestWaypoint = waypoint;
    //        }
    //    }

    //    return nearestWaypoint;
    //}
}
