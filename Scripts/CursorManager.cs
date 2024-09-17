using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool lastIsMaximized = false; // Tracks whether the game window was maximized in the previous frame

    // Start is called before the first frame update
    void Start()
    {
        ApplyCursorSettings(); // Apply the initial cursor settings based on the current window state
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game window is maximized by comparing the screen dimensions to the current resolution
        bool isMaximized = (Screen.width == Screen.currentResolution.width && Screen.height == Screen.currentResolution.height);

        // Check if the maximized state has changed since the last frame
        if (isMaximized != lastIsMaximized)
        {
            lastIsMaximized = isMaximized; // Update the maximized state
            ApplyCursorSettings(); // Apply new cursor settings based on the updated state
        }

        // Optionally, handle the escape key to show the cursor and unlock it
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true; // Make the cursor visible
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor from the center of the screen
        }
    }

    // Applies the cursor settings based on whether the game is maximized
    void ApplyCursorSettings()
    {
        if (lastIsMaximized)
        {
            Cursor.visible = false; // Hide the cursor when the game is maximized
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        }
        else
        {
            // Reset cursor visibility and lock state in case the window is not maximized
            Cursor.visible = true; // Make the cursor visible when not maximized
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
    }
}
