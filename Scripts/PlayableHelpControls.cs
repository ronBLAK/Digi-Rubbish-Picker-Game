using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayableHelpControls : MonoBehaviour
{
    [SerializeField] private GameObject playableControlsInstructionPanel;

    public void Update()
    {
        if (playableControlsInstructionPanel.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Continue()
    {
        playableControlsInstructionPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
}
