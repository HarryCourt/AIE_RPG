using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStartMenu;    // Is the start of the scene in a menu?

    public enum GameState {Menu, Playing, GameOver}

    // Start is called before the first frame update
    void Start()
    {
        if (isStartMenu) { return; }
        else 
        {
            // Hide cursor.
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
