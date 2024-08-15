using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraInstructionCollider : MonoBehaviour
{
    [SerializeField] private GameObject playableControlsInstructionPanel;
    [SerializeField] private TextMeshProUGUI instruction;

    public string cameraInstructions;

    public void Update()
    {
        if (playableControlsInstructionPanel.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playableControlsInstructionPanel.SetActive(true);
        instruction.text = cameraInstructions;
    }
}
