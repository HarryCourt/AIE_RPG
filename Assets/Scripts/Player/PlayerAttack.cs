using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    /// <summary>
    /// OBSOLETE SCIRPT. NOW USED IN "PlayerProperties.cs".
    /// </summary>
    public GameObject weaponEquiped;

    // Start is called before the first frame update
    void Start()
    {
        weaponEquiped.GetComponent<WeaponProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        var weaponScript = weaponEquiped.GetComponent<WeaponProperties>();

        if (Input.GetMouseButtonDown(0))
        {
            weaponScript.Attack();
        }
    }
}
