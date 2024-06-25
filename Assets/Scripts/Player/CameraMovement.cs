using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Speed of rotation in degrees per second
    public float movementSpeed = 5.0f;   // Speed of movement in units per second

    void Update()
    {
        // Rotation Left & Right
        float horizontalRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, horizontalRotation);
    }
}

