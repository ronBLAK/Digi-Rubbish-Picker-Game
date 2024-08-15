using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool lastIsMaximized = false;

    void Start()
    {
        ApplyCursorSettings();
    }

    void Update()
    {
        // Check if the game window is maximized by comparing screen dimensions
        bool isMaximized = (Screen.width == Screen.currentResolution.width && Screen.height == Screen.currentResolution.height);

        // Check if maximized state has changed
        if (isMaximized != lastIsMaximized)
        {
            lastIsMaximized = isMaximized;
            ApplyCursorSettings();
        }

        // Optionally, handle escape key to show cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void ApplyCursorSettings()
    {
        if (lastIsMaximized)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            // Reset cursor visibility in case it's not maximized
            Cursor.visible = true; // or set it to false based on your requirements
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
