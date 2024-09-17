using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraInstructionCollider : MonoBehaviour
{
    // Serialized fields to set in the Unity Editor
    [SerializeField] private GameObject playableControlsInstructionPanel; // Panel showing the playable controls instructions
    [SerializeField] private TextMeshProUGUI instruction; // Text component to display the instructions

    public string cameraInstructions; // Instructions text to be displayed when the player interacts with this object

    // Update is called once per frame
    public void Update()
    {
        // Check if the instruction panel is currently active
        if (playableControlsInstructionPanel.activeSelf == true)
        {
            // Unlock and show the cursor when the instruction panel is active
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } 
        else
        {
            // Lock and hide the cursor when the instruction panel is not active
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider other)
    {
        // Activate the instruction panel and update the instruction text
        playableControlsInstructionPanel.SetActive(true);
        instruction.text = cameraInstructions;
    }
}
