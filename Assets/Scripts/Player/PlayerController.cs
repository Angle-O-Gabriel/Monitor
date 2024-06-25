using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        this.transform.position = Waypoint.current.transform.position;
    }

}
