using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoreItem : MonoBehaviour
{
    public int price = 5;

    // Display
    public Mesh itemMesh;
    public Material itemMaterial;

    public UnityEvent function;

    private GameObject playerObject;
    private PlayerProperties playerProperties;

    private bool canBuy = true;
    private float cooldown = 0.5f;

    private void Awake()
    {
        // Set mesh and materials to object.
        GetComponent<MeshFilter>().mesh = itemMesh;
        GetComponent<MeshRenderer>().material = itemMaterial;
    }

    private void Update()
    {
        // If the player can no longer buy, start the timer.
        if (!canBuy)
        {
            cooldown -= Time.deltaTime;

            if (cooldown < 0) { canBuy = true; cooldown = 0.5f; }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the sphere, we can talk to them.
        if (other.CompareTag("Player"))
        {
            playerObject = other.gameObject; // Set the player object.

            playerProperties = playerObject.GetComponent<PlayerProperties>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // If the player interacts and has the money, give the player the item they requested.
        if (Input.GetButtonDown("Interact") && playerProperties.coins >= price && canBuy)
        {
            print("Bought an item.");

            // Subtract the price, and do the function.
            playerProperties.coins -= price;
            function.Invoke();
            
            // The player now has to wait.
            canBuy = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerObject = null;                        // Set player object to null.
    }



    #region Shop Functions
    public void GiveHealth(int healthToGive)
    {
        if (playerProperties.health < playerProperties.healthValue)
        {
            playerProperties.health += healthToGive;
        }
        else { playerProperties.coins += price; }
        //return healthToGive;
    }

    public void UpgradeHealth(int healthValueUpgrade)
    {
        playerProperties.healthValue += healthValueUpgrade;

        //return healthValueUpgrade;
    }

    public void RandomColorToPlayer()
    {
        print("Giving random colour");
        playerObject.GetComponent<Renderer>().material.color = new Color
            (
            Random.Range(0f,1f),  // Red
            Random.Range(0f, 1f),  // Green
            Random.Range(0f, 1f)    // Blue
            );

        //return color;
    }
    #endregion
}
