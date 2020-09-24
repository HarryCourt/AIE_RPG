using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class EnemyProperties : MonoBehaviour
{
    // Variables
    public int health = 5;              // The amount of health the Enemy has.
    public int damageValue = 1;         // The amount of health the Enemy can take away.
    
    public float cooldownValue = 0.6f;    // The value which the timer will reset.
    private float cooldownTimer;        // The timer of the cool down.

    private bool hasDied;

    // Game objects and Transforms
    public Collider playerDamageZone;
    public Transform itemDrop;


    // public TextMesh damageText;
    // public TextMesh enemyName;
    // --------------------------
    // Audio Clips WIP
    public AudioSource audioSource;
    public AudioClip damage1;
    // public AudioClip ambient1;


    private void Start()
    {
        Physics.IgnoreLayerCollision(1, 8); // Only react to weapon collision.
        cooldownTimer = 0;  // Reset the timer.
        hasDied = false;

        audioSource.clip = damage1;
    }

    private void Update()
    {
        // damageText.text = health.ToString();
        // If the health reaches 0, set the game objec to false and grab some coins.
        if (health <= 0 && !hasDied) 
        {
            Die();
            hasDied = true;
        }                       
        if (cooldownTimer > 0) { cooldownTimer -= Time.deltaTime; }     // Make the cooldown count down.
    }

    private void OnTriggerStay(Collider other)
    {
        Damage(other);
    }

    #region Enemy Functions
    // Get the distance from the player.
    public bool DistanceToPlayer(float minimumDistance)
    {
        // Find the player and the distance to player.
        var target = GameObject.FindGameObjectWithTag("Player");
        var distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        // If the distance is shorter than minimum distance, go attack the player.
        if (distanceToPlayer < minimumDistance) { return true; }
        else { return false; }
    }

    // Giving damage to the Player.
    public void Damage(Collider collider)
    {
        // If the player has been detected and has not taken damage, give it damage!
        if (collider.tag == "Player")
        {
            if (cooldownTimer <= 0)
            {
                cooldownTimer = cooldownValue;
                collider.GetComponent<PlayerProperties>().health -= 1;      // Subtract one heart.
            }
        }
    }

    // The functions that would cause the death of an object.
    public void Die()
    {
        Destroy(gameObject.GetComponent<MeshRenderer>());       // Destroy renderer.
        Destroy(gameObject.GetComponent<BoxCollider>());        // Disable collision.
        Destroy(playerDamageZone.gameObject);                   // Destroy damage zone.

        Instantiate(itemDrop, new Vector3(transform.position.x + Random.Range(-1f,1f), 0.5f, transform.position.z + Random.Range(-1f,1f)), Quaternion.identity);
    }
    #endregion
}
