using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void UnactivateObject(GameObject objectToDisable)
    {
        objectToDisable.gameObject.SetActive(false);
    }

    public void SwitchToScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }
}
