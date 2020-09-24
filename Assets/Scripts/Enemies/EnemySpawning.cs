using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyProperties
{
    public GameObject enemyToSpawn;
    public float timeValue;
    private float timeLeft;

    private EnemyProperties enemyProp;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeValue;
    }

    // Update is called once per frame
    void Update()
    {
        // If the distance to the player is less than 20, start counting down.
        if (DistanceToPlayer(20f))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) { Instantiate(enemyToSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); timeLeft = timeValue; }
        }
        
    }
}
