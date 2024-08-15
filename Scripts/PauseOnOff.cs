using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnOff : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool gamePaused = false;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (gamePaused == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                gamePaused = true;

                // make the cursor visible
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                gamePaused = false;

                // make the cursor invisible and inusable
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
