using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    float inputX, inputZ;
    [SerializeField] float rotationSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if(inputX != 0)
        {
            rotate();
        }

        //if(inputZ != 0)
        //{
        //    move();
        //}
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, inputX * Time.deltaTime * rotationSpeed, 0f));
    }

    //private void move()
    //{
    //    transform.position += transform.forward * inputZ * Time.deltaTime;
    //}
}
