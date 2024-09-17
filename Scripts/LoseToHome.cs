using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseToHome : MonoBehaviour
{
    // Name of the scene to load when returning to the home screen
    public string homeSceneName;

    // Update is called once per frame
    public void Update()
    {
        // Ensure the cursor is visible and not locked, so the player can interact with UI elements
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Method to load the home scene
    public void Home()
    {
        // Load the scene specified by the homeSceneName variable
        SceneManager.LoadScene(homeSceneName);
    }
}
