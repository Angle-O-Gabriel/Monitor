using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float lerpSpeed = 5.0f;
    // Update is called once per frame
    private void Update()
    {
        //this.transform.position = Waypoint.current.transform.position;
        Vector3 currentPosition = transform.position;
        Vector3 newTargetPosition = Waypoint.current.transform.position;

        // Interpolate between the current position and the target position
        this.transform.position = Vector3.Lerp(
            currentPosition,
            new Vector3(newTargetPosition.x, currentPosition.y, newTargetPosition.z),
            lerpSpeed * Time.deltaTime
        );

    }

}
