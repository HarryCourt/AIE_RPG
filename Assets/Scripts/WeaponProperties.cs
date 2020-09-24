using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProperties : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 3;
    
    private bool hasntHit = false;

    public Animation anim;
    public AnimationClip attack;
    public AnimationClip altAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (!anim.isPlaying) { hasntHit = false; }  // If the animation is not playing, allow to hit again.
    }

    private void OnTriggerEnter(Collider other)
    {
        /// /////////////////////
        /// DEALING DAMAGE
        /// /////////////////////
        if (other.tag == "Enemy")
        {
            var enemyScript = other.gameObject.GetComponent<EnemyProperties>(); // We know we've hit the enemy, so grab its script.

            // If the animation is playing, deal damage!
            if (anim.isPlaying)
            { 
                if (!hasntHit)
                {
                    print("Swung and hit an enemy.");
                    hasntHit = true;

                    enemyScript.health -= Random.Range(minDamage, maxDamage);
                    enemyScript.audioSource.Play();
                }
            }
        }
    }

    public void Attack()
    {
        // If the left mouse is pressed, play default attack.
        if (Input.GetMouseButtonDown(0))
        {
            anim.clip = attack;
            anim.Play();
        }
        // If the right mouse is pressed, play the alternate attack.
        else if (Input.GetMouseButtonDown(1))
        {
            anim.clip = altAttack;
            anim.Play();
        }
    }
}
