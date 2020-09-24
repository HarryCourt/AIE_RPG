using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    public Vector3 offset;              // Where the camera is from the player.
    public Transform target;    // The transform we need to follow
    private Vector3 velocity = Vector3.zero;

    public float smoothSpeed = 0.1f;

    void Update()
    {
        var mousePosition = Input.mousePosition;

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.position, Vector3.up, 100f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.position, Vector3.up, -100f * Time.deltaTime);
        }


        //transform.LookAt(objectToFollow);

        ///
        Vector3 desiredPosition = target.position + offset;                                                                 // Get the objects position, then add the offset.        
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);        // Smoothen the camera movement.
        //
        transform.position = smoothPosition;    // Set camera position to the smooth position                                
        transform.LookAt(target);       // Look at the object.
        ///
    }
}
