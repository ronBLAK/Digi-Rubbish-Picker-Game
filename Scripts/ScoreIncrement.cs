using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIncrement : MonoBehaviour
{
    public static float currentScore = 0; // Static score that is shared across all instances

    // Tier system for different types of rubbish
    private float iceCreamScore = 2; // Score value for ice cream
    private float cakeScore = 3;     // Score value for cake
    private float donutScore = 4;    // Score value for donut

    public TextMeshProUGUI scoreUI;   // Reference to the UI text component that displays the score

    public bool scoreIncremented = false; // Flag to check if score has been incremented (currently unused)

    private void Start()
    {
        // Initialize the score UI with the current score at the start
        scoreUI.text = "Score: " + currentScore.ToString();
    }

    public void IceCreamScore()
    {
        // Increment the score by the value assigned for ice cream
        currentScore += iceCreamScore;
        // Update the score display
        scoreUI.text = "Score: " + currentScore.ToString();

        // Log the updated score to the console
        Debug.Log("score incremented. current score: " + currentScore);
    }

    public void CakeScore()
    {
        // Increment the score by the value assigned for cake
        currentScore += cakeScore;
        // Update the score display
        scoreUI.text = "Score: " + currentScore.ToString();

        // Log the updated score to the console
        Debug.Log("score incremented. current score: " + currentScore);
    }

    public void DonutScore()
    {
        // Increment the score by the value assigned for donut
        currentScore += donutScore;
        // Update the score display
        scoreUI.text = "Score: " + currentScore.ToString();

        // Log the updated score to the console
        Debug.Log("score incremented. current score: " + currentScore);
    }
}
