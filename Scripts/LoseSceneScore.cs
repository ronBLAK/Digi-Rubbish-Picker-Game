using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Namespace for TextMeshPro components

public class LoseSceneScore : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component for displaying the score on the lose screen
    [SerializeField] private TextMeshProUGUI loseScreenScoreText;

    // Update is called once per frame
    public void Update()
    {
        // Update the score display on the lose screen
        DisplayScore(loseScreenScoreText);
    }

    // Method to set the text of the score display
    private void DisplayScore(TextMeshProUGUI scoreToDisplay)
    {
        // Format and set the text to show the current score
        scoreToDisplay.text = $"Your Current Score is: {ScoreIncrement.currentScore.ToString()}";
    }
}
