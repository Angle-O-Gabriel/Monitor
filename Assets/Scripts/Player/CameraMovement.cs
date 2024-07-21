using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Speed of rotation in degrees per second
    public float movementSpeed = 5.0f;   // Speed of movement in units per second

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null) return;
        // Rotation Left & Right

        float horizontalRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, horizontalRotation);
    }

    public void TurnRight()
    {
        float currentYRotation = gameObject.transform.eulerAngles.y;
        float targetYRotation = currentYRotation + 45f;
        LeanTween.rotateY(gameObject, targetYRotation, 0.5f).setEase(LeanTweenType.easeOutExpo);
    }

    public void TurnLeft()
    {
        float currentYRotation = gameObject.transform.eulerAngles.y;
        float targetYRotation = currentYRotation - 45f;
        LeanTween.rotateY(gameObject, targetYRotation, 0.5f).setEase(LeanTweenType.easeOutExpo);
    }
}

