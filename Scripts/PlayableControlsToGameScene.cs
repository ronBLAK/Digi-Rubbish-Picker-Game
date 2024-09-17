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
        SceneManager.LoadScene(sceneName); // controls a separate scene change that cannot be controlled by the play function from the other script
    }
}
