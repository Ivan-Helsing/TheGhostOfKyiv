using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] TMP_Text totalCoinsText;
    [SerializeField] TMP_Text currentFuelText;

    private const int ResetToDefaultValue = 0;

    void Start()
    {
        HighScoreView();
        LastScoreView();
        TotalCoinsSetAndView();
    }



    void Update()
    {
        
    }

    private void TotalCoinsSetAndView()
    {
        int totalCoins = PlayerPrefs.GetInt(PlayGameUI.TotalCoinsKey, 0);
        int lastGameReward = PlayerPrefs.GetInt(PlayGameUI.CurrentCoinsKey, 0);

        totalCoins += lastGameReward;
        PlayerPrefs.SetInt(PlayGameUI.TotalCoinsKey, totalCoins);
        PlayerPrefs.SetInt(PlayGameUI.CurrentCoinsKey, ResetToDefaultValue);

        totalCoinsText.text = $"{totalCoins}";
    }

    private void LastScoreView()
    {
        int lastScore = PlayerPrefs.GetInt(PlayGameUI.LastScoreKey, 0);

        lastScoreText.text = $"{lastScore}";
    }

    private void HighScoreView()
    {
        int highScore = PlayerPrefs.GetInt(PlayGameUI.HighScoreKey, 0);

        highScoreText.text = $"{highScore}";
    }


}
