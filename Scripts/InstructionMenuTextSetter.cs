using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InstructionMenuTextSetter : MonoBehaviour
{
    [SerializeField] public GameObject instructionMenuPanel;
    private TextMeshProUGUI instructions;

    void Start()
    {
        instructions = instructionMenuPanel.GetComponentInChildren<TextMeshProUGUI>();

        instructions.text = "hello ";
    }
}
