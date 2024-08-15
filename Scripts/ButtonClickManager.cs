using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickManager : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private GameObject instructionAndPauseMenu;
    [SerializeField] private GameObject controlsMenu;

    public void Play()
    {
        SceneManager.LoadScene(scene);
    }

    public void Help()
    {
        instructionAndPauseMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("application is quit");
    }

    public void QuitInstructions()
    {
        instructionAndPauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ControlsMenu()
    {
        instructionAndPauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void QuitControlsMenu()
    {
        instructionAndPauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }
}
