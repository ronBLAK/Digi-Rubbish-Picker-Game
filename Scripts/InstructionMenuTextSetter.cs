using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro; // Namespace for TextMeshPro components
using UnityEngine;

public class InstructionMenuTextSetter : MonoBehaviour
{
    // Reference to the instruction menu panel GameObject
    [SerializeField] public GameObject instructionMenuPanel;
    private TextMeshProUGUI instructions; // Reference to the TextMeshProUGUI component for setting text

    void Start()
    {
        // Find the TextMeshProUGUI component within the children of the instruction menu panel
        instructions = instructionMenuPanel.GetComponentInChildren<TextMeshProUGUI>();

        // Set the initial text for the instructions
        instructions.text = "hello ";
    }
}
