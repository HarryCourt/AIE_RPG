using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCStore : MonoBehaviour
{
    // Variables
    public GameObject canvas;

    public List<Transform> itemLocations;

    public string dialouge1 = "I'm a generic NPC.";

    private GameObject playerObject;

    private void Awake()
    {
        // Set the NPC text in the UI
        //dialogueText.text = dialouge1;          // Set Dialogue
        canvas.SetActive(false);                // Dissapear the Panel UI

        //print(dialogueText);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the sphere, we can talk to them.
        if (other.CompareTag("Player"))
        {
            print("Player is in NPC's reach.");
            playerObject = playerObject.gameObject; // Set the player object.
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // If the player interacts, give the player some Dialouge.
        if (Input.GetButton("Interact"))
        {

            //Debug.Log(name + " says: " + dialouge1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the panel is active, get rid of it. Else, don't bother wasting time.
        if (canvas.activeSelf) { canvas.SetActive(false); }
        else { return; }
        
        playerObject = null;                        // Set player object to null.
    }

    #region Shop Functions
    /// <summary>
    /// Surely theres a better way to do "var playerProp = playerObject.GetComponent<PlayerProperties>();"?
    /// </summary>

    public void NPCTemplate()
    {
        var playerProp = playerObject.GetComponent<PlayerProperties>();
    }

    public void GiveHealth(int healthToGive)
    {
        var playerProp = playerObject.GetComponent<PlayerProperties>();

        playerProp.health += healthToGive;

        //return healthToGive;
    }

    public void UpgradeHealth(int healthValueUpgrade)
    {
        var playerProp = playerObject.GetComponent<PlayerProperties>();

        playerProp.healthValue += healthValueUpgrade;

        //return healthValueUpgrade;
    }

    public void RandomColorToPlayer(Color color)
    {
        playerObject.GetComponent<Renderer>().material.color = color;

        //return color;
    }
    #endregion
}
