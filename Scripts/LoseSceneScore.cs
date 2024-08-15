using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseSceneScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loseScreenScoreText;

    public void Update()
    {
        DisplayScore(loseScreenScoreText);
    }

    private void DisplayScore(TextMeshProUGUI scoreToDisplay)
    {
        scoreToDisplay.text = $"Your Current Score is: {ScoreIncrement.currentScore.ToString()}";
    }
}
