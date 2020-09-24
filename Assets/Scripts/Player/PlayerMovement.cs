using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 15f;
    public float jumpSpeed = 20f;
    public GameObject playerCamera;

    CharacterController cc;
    private PlayerProperties playerProperties;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerProperties = GetComponent<PlayerProperties>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Make player go fowards where the camera is facing.
        float yRotation = playerCamera.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);

        // Get the inputs and multiply by speed.
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;

        // Put inputs into Vectors and clamp the speed.
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, moveSpeed); // Limit speed

        var gravity = Physics.gravity;

        // Move the player as long as the health is above 0.
        if (playerProperties.health > 0)
        {
            movement = transform.TransformDirection(movement);
            cc.Move(movement * Time.deltaTime);
            cc.SimpleMove(gravity);
        }
        else { return; }
    }
}
