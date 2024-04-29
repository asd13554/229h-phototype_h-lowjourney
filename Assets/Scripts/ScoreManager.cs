using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TMP_Text scoreText;
    public TMP_Text maxScoreText;

    private int score = 0;
    private int maxScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", score);
        scoreText.text = score.ToString() + " POINTS";
        maxScoreText.text = "HIGH SCORE : " + maxScore.ToString();
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if (maxScore < score)
        {
            PlayerPrefs.SetInt("maxScore",score);
        }
    }
}
