using System;
using TMPro;
using UnityEngine;

public class UI_ScoreDisplay : MonoBehaviour
{
    public Score score;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        score.OnScoreChanged += OnScoreChanged;
        score.OnScoreInitialized += OnScoreInitialized;
    }

    private void OnScoreChanged(float newScore, float scoreamoauntChanged)
    {
        //Debug.Log(newHealth + ":" + scoreamountChanged);
        textComponent.text = newScore.ToString();
    }

    private void OnScoreInitialized(float currentScore)
    {
        textComponent.text = currentScore.ToString();
    }
}
