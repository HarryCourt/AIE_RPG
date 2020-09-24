using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {Menu, Playing, GameOver}

    // Start is called before the first frame update
    void Start()
    {
        // Hide cursor.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
