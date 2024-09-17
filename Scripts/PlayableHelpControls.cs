using System.Collections;
using System.Collections.Generic;
using System.Threading; // Namespace for threading (not used in this script)
using UnityEngine;

public class PlayableHelpControls : MonoBehaviour
{
    // Reference to the GameObject containing the help controls instruction panel
    [SerializeField] private GameObject playableControlsInstructionPanel;

    // Update is called once per frame
    public void Update()
    {
        // Check if the help controls instruction panel is active
        if (playableControlsInstructionPanel.activeSelf)
        {
            // Unlock the cursor if the instruction panel is visible
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Method to be called when continuing from the help controls instruction panel
    public void Continue()
    {
        // Deactivate the instruction panel
        playableControlsInstructionPanel.SetActive(false);
        // Resume the game time
        Time.timeScale = 1;
        // Hide the cursor
        Cursor.visible = false;
    }
}
