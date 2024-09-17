using UnityEngine;
using TMPro; // Include this if you are using Unity UI
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public int minutes = 0; // Number of minutes for the countdown, set in the Inspector
    public int seconds = 05; // Number of seconds for the countdown, set in the Inspector
    private float totalTime; // Total time in seconds for the countdown
    public float remainingTime; // Time left in the countdown
    public TextMeshProUGUI timerText; // Reference to the UI Text component for displaying the timer

    private ScoreIncrement scoreIncrement; // Reference to the ScoreIncrement component
    public GameObject scoreIncrementGO; // GameObject that contains the ScoreIncrement component

    // Start is called before the first frame update
    void Start()
    {
        // Get the ScoreIncrement component from the specified GameObject
        scoreIncrement = scoreIncrementGO.GetComponent<ScoreIncrement>();

        // Convert minutes and seconds to total time in seconds
        totalTime = minutes * 60 + seconds;
        remainingTime = totalTime;

        // Update the timer display to show the starting time
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there's remaining time left in the countdown
        if (remainingTime > 0)
        {
            // Decrease the remaining time by the time that has passed since the last frame
            remainingTime -= Time.deltaTime;

            // Update the timer display to reflect the new time
            UpdateTimerDisplay();

            // If the timer has reached zero or below
            if (remainingTime <= 0)
            {
                remainingTime = 0; // Ensure the timer doesn't go negative
                TimerEnded(); // Call the method to handle the timer ending
            }
        }
    }

    // Updates the timer display on the UI
    void UpdateTimerDisplay()
    {
        // Calculate minutes and seconds from the remaining time
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Update the UI text component to show the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method called when the timer ends
    public void TimerEnded()
    {
        // Load the scene named "LoseScene" to handle the end of the timer
        SceneManager.LoadScene("LoseScene");
    }
}
