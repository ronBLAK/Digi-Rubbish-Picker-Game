using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseToHome : MonoBehaviour
{
    public string homeSceneName;

    public void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Home()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}
