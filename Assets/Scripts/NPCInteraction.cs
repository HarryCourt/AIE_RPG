using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    // Variables
    public GameObject canvas;
    public Text nameText;
    public Text dialogueText;

    // Animation stuff
    public Transform idleStance;
    public Transform talkingStance;

    public string dialouge1 = "I'm a generic NPC.";

    private void Awake()
    {
        // Set the NPC text in the UI
        nameText.text = name;                   // Name of the NPC
        dialogueText.text = dialouge1;          // Set Dialogue
        canvas.SetActive(false);                // Dissapear the Panel UI

        idleStance.gameObject.SetActive(true);      // Set the idle animation true
        talkingStance.gameObject.SetActive(false);  // Set the talking animation false

        //print(dialogueText);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the sphere, we can talk to them.
        if (other.CompareTag("Player"))
        {
            print("Player is in NPC's reach.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // If the player interacts, give the player some Dialouge.
        if (Input.GetButton("Interact"))
        {
            canvas.SetActive(true);                 // Show the NPC's chatting box.

            talkingStance.gameObject.SetActive(true);
            idleStance.gameObject.SetActive(false);
            //Debug.Log(name + " says: " + dialouge1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the panel is active, get rid of it. Else, don't bother wasting time.
        if (canvas.activeSelf) { canvas.SetActive(false); }
        else { return; }

        idleStance.gameObject.SetActive(true);      // Set the idle animation true
        talkingStance.gameObject.SetActive(false);  // Set the talking animation false
    }
}
