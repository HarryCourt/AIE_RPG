using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioSource audioSource;
    private bool canDestroy = false;
    private float timer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        var z = transform.rotation.z;
        z = 90f;
        transform.Rotate(0,0,90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0); //rotates 50 degrees per second around X axis

        if (canDestroy)
        { 
            timer -= Time.deltaTime;
            if (timer < 0) Destroy(gameObject);
        }
        print(timer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();                                 // Destroy Game Object
            GetComponent<MeshRenderer>().enabled = false;       // Disable the mesh renderer
            GetComponent<CapsuleCollider>().enabled = false;    // Disable the collider

            var playerScript = other.GetComponent<PlayerProperties>();  // We know we've collided with the player, so get it's script.

            playerScript.coins += 1;    // Add coins

            canDestroy = true;
        }
    }
}
