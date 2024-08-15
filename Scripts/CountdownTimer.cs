using UnityEngine;
using TMPro; // Include this if you are using Unity UI
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public int minutes = 0; // Number of minutes to set in the Inspector
    public int seconds = 05; // Number of seconds to set in the Inspector
    private float totalTime;
    public float remainingTime;
    public TextMeshProUGUI timerText; // Reference to UI Text component

    private ScoreIncrement scoreIncrement;
    public GameObject scoreIncrementGO;

    void Start()
    {
        scoreIncrement = scoreIncrementGO.GetComponent<ScoreIncrement>();

        // Convert minutes and seconds to total time in seconds
        totalTime = minutes * 60 + seconds;
        remainingTime = totalTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay();
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                TimerEnded();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void TimerEnded()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
