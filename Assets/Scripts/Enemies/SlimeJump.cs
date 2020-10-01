using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJump : MonoBehaviour
{
    // Variables
    public float launchSpeed = 5f;      // The speed that the slime will launch from.
    public float waitTimeValue = 3f;    // The time that the slime will take.
    public float waitTime;              // Time needed before the slime can launch again.
    public float distance = 10f;

    private Rigidbody rb;               // The rigidbody of the slime
    private GameObject target;          // The target once the player is detected.
    private EnemyProperties enemyProp;  // Enemy properties script.

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();                         // Get the Rigidbody component for later.
        enemyProp = GetComponent<EnemyProperties>();            // Get the enemy properties script.
        target = GameObject.FindGameObjectWithTag("Player");    // Find gameobject with Player

        waitTime = waitTimeValue;   // Set the value.
}

    private void Update()
    {
        if (enemyProp.DistanceToPlayer(distance))
        {
            Attack();
        }
    }

    // This is the movement for the slime. 
    void Attack()
    {
        // This code was copy and pasted, sorry Daniel :(
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);


        // If the wait time is above 0, subtract from it.
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        // If the timer is below 0, make the slime jump and reset it.
        else if (waitTime <= 0)
        {
            rb.velocity = launchSpeed * (transform.forward + transform.up); // Launch diagonally.
            waitTime = waitTimeValue;
        }
    }
}
