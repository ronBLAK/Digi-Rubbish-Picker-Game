using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIncrement : MonoBehaviour
{
    public static float currentScore = 0;

    // tier system for different rubbish
    private float iceCreamScore = 2;
    private float cakeScore = 3;
    private float donutScore = 4;

    public TextMeshProUGUI scoreUI;

    public bool scoreIncremented = false;

    private void Start()
    {
        scoreUI.text = "Score: " + currentScore.ToString();
    }

    public void IceCreamScore()
    {
        currentScore += iceCreamScore;
        scoreUI.text = currentScore.ToString();

        Debug.Log("score incremented. current score: " + currentScore);
    }

    public void CakeScore()
    {
        currentScore += cakeScore;
        scoreUI.text = currentScore.ToString();

        Debug.Log("score incremented. current score: " + currentScore);
    }

    public void DonutScore()
    {
        currentScore += donutScore;
        scoreUI.text = currentScore.ToString();

        Debug.Log("score incremented. current score: " + currentScore);
    }
}
