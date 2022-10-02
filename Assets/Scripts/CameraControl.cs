using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothSpeed = 0.2f;
    public Vector3 offset;
    //public GameObject player;
    public float sensitivity;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    
    void LateUpdate()
    {      
        if (Input.GetMouseButton(1))
        {
            // Orbit camera
            float rotateHorizontal = Input.GetAxis("Mouse X");
            
            transform.RotateAround(target.transform.position, Vector3.up, rotateHorizontal * sensitivity); // Horizontal
            //transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity); // Vertical
 
            // Rotate player horizontally as well
            target.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
 
        }
    }
}
