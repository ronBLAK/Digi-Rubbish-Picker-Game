using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayableControlsToGameScene : MonoBehaviour
{
    public string sceneName;

    // Update is called once per frame
    void OnTriggerEnter()
    {
        SceneManager.LoadScene(sceneName);
    }
}
