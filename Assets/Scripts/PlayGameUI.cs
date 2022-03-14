using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGameUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier = 3f;

    public const string HighScoreKey = "HighScore";

    private float score;
    //private int coins;


    void Start()
    {
        
    }

    void Update()
    {
        ScoreCounter();
    }

    private void CoinsCounter()
    {
        //

    }

    private void ScoreCounter ()
    {
        score += scoreMultiplier * Time.deltaTime;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
        int currentHighscore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > currentHighscore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }

    }



}
