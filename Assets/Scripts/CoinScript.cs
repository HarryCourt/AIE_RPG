using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform meshCollection;
    public int coinAmount = 1;
    public Vector3 rotationForCoin;

    private bool canDestroy = false;
    private float timer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotationForCoin);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0); //rotates 50 degrees per second around X axis

        if (canDestroy)
        { 
            timer -= Time.deltaTime;
            if (timer < 0) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();                                 // Destroy Game Object

            if (meshCollection == null) { GetComponent<MeshRenderer>().enabled = false; }         // Disable mesh renderer if it's directly on the object,
            if (meshCollection != null) { meshCollection.gameObject.SetActive(false); }          // Disable collection of meshes in gameObject.

            GetComponent<CapsuleCollider>().enabled = false;    // Disable the collider

            var playerScript = other.GetComponent<PlayerProperties>();  // We know we've collided with the player, so get it's script.

            playerScript.coins += coinAmount;    // Add coins

            canDestroy = true;
        }
    }
}
