using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGameUI : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier = 3f;

    public const string HighScoreKey = "HighScore";
    public const string LastScoreKey = "LastScore";

    private float score;

    [Header("Coins")]
    [SerializeField] TMP_Text coinsText;
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

        SetHighScore(currentHighscore);
        SetLastScore();

    }

    private void SetLastScore()
    {
        PlayerPrefs.SetInt(LastScoreKey, Mathf.FloorToInt(score));
    }

    private void SetHighScore(int currentHighscore)
    {
        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
