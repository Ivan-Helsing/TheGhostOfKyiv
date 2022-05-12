using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shed : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] TMP_Text totalCoinsText;
    [SerializeField] TMP_Text priceCoinsTExt;

    private const int ResetToDefaultValue = 0;

    [Header("Score")]
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text priceHighScoreText;

    [Header("Aircraft")]
    [SerializeField] Sprite[] aircraftLevel;


    private void Update()
    {
        HighScoreView();
        TotalCoinsSetAndView();
    }

    private void AircraftChanger()
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

    private void HighScoreView()
    {
        int highScore = PlayerPrefs.GetInt(PlayGameUI.HighScoreKey, 0);

        highScoreText.text = $"{highScore}";
    }




}
