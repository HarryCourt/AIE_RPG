using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStartMenu;    // Is the start of the scene in a menu?

    public enum GameState {Menu, Playing, GameOver}
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        if (isStartMenu) { return; }
        else
        {
            // Show cursor.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        /**
        switch (gameState)
        {
            case GameState.Menu:
                // Hide cursor.
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                break;

            case GameState.Playing:
                // Hide cursor.
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;

                break;

            case GameState.GameOver:
                // Hide cursor.
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                break;
        
        }**/
    }
}
