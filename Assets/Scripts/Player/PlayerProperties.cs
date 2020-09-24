using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour
{
    // Variables
    public int healthValue = 4; // The health value
    public int health = 4;      // This is to work with hearts.
    public int coins = 0;       // Currency that the player has.

    public GameObject weaponEquiped;

    // GUI
    public Text healthText;
    public Text coinText;

    public Transform diePanel;
    public Text dieText;

    // --------
    private CharacterController cc;
    private float deathTimer;

    
    //public Image[] hearts;
    //public List<Image> hearts;
    //public Image heartSpr;

    /// <summary>
    /// TO DO:
    /// 1. Make enemy able to attack the player. (Done)
    /// 2. Update health after taking damage. (Done)
    /// 3. Replace text with Hearts (Couldn't do)
    /// 4. Add coins (Done)
    /// 
    /// NOTE WITH WEAPONS:
    /// WEAPONS IS EXTREMELY UNDER-DEVELOPED. NEEDS TO BE WORKED ON MORE
    /// 
    /// </summary>

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        diePanel.gameObject.SetActive(false);

        weaponEquiped.GetComponent<WeaponProperties>();

        deathTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Change variables.
        healthText.text = health + "/" + healthValue;
        coinText.text = "$" + coins;

        WeaponAttack(); // Have the player able to attack.

        // Instant death
        if (Input.GetKeyDown(KeyCode.BackQuote)) health = 0;
        if (Input.GetKeyDown(KeyCode.F2)) coins += 15;

        if (health > healthValue) { health = healthValue; }

        if (health <= 0) { Die(); }


    }

    #region Player Functions
    private void WeaponAttack()
    {
        var weaponScript = weaponEquiped.GetComponent<WeaponProperties>();

        weaponScript.Attack();
    }

    // If the player dies, pick a random spawn point and teleport the player there.
    private void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;   // Disable components so they aren't visible. (This really only works well if there was another player in the scene)
        cc.enabled = false;                             // Disable the character controller so the player cannot move. (Also helps with teleportation!)
        diePanel.gameObject.SetActive(true);            // Display the panel.
        weaponEquiped.gameObject.SetActive(false);      // Disable the weapon the user is holding.

        dieText.text = "You will respawn in " + Mathf.RoundToInt(deathTimer) + " seconds."; // Set the text correctly.

        
        

        // Getting a spawn point (The player will loop through all spawns. I dunno how to fix it)
        var spawnPoint = GameObject.FindGameObjectsWithTag("Spawn Point");
        var index = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[index].transform.position;  // Set the player back to spawn.

        deathTimer -= Time.deltaTime;

        if (deathTimer < 0f) 
        {
            // Re-enable the components
            GetComponent<MeshRenderer>().enabled = true;

            cc.enabled = true;                                          // Re-enable the character controller.
            diePanel.gameObject.SetActive(false);                       // Remove the panel.
            weaponEquiped.gameObject.SetActive(true);                   // Re-enable weapon.

            health = healthValue;                                       // Set health back.
            deathTimer = 5f;                                            // Reset timer.
        }
    }
    #endregion
}
