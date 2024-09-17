using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickManager : MonoBehaviour
{
    // Serialized fields allow you to set these values in the Unity Editor
    [SerializeField] private string scene; // The name of the scene to load when Play is called
    [SerializeField] private GameObject instructionAndPauseMenu; // The GameObject for the instructions and pause menu
    [SerializeField] private GameObject controlsMenu; // The GameObject for the controls menu

    // Method to load the specified scene
    public void Play()
    {
        SceneManager.LoadScene(scene); // Loads the scene specified in the 'scene' variable
    }

    // Method to show the instructions and pause menu
    public void Help()
    {
        instructionAndPauseMenu.SetActive(true); // Activates the instructions and pause menu
    }

    // Method to quit the application
    public void Quit()
    {
        Application.Quit(); // Quits the application
        Debug.Log("application is quit"); // Logs a message to the console (useful for debugging in the editor) actual button exits the game
    }

    // Method to hide the instructions and resume the game (works for all the instruction panels across all scenes)
    public void QuitInstructions()
    {
        instructionAndPauseMenu.SetActive(false); // Deactivates the instructions and pause menu
        Time.timeScale = 1f; // Resumes the game if it was paused
    }

    // Method to show the controls menu
    public void ControlsMenu()
    {
        instructionAndPauseMenu.SetActive(false); // Hides the instructions and pause menu
        controlsMenu.SetActive(true); // Shows the controls menu
    }

    // Method to hide the controls menu and show the instructions again
    public void QuitControlsMenu()
    {
        instructionAndPauseMenu.SetActive(true); // Shows the instructions and pause menu
        controlsMenu.SetActive(false); // Hides the controls menu
    }
}
