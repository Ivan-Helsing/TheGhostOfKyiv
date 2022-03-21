using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text fuelText;



    void Start()
    {
        HighScoreView();
        LastScoreView();
    }

    private void LastScoreView()
    {
        int lastScore = PlayerPrefs.GetInt(PlayGameUI.LastScoreKey, 0);

        lastScoreText.text = $"{lastScore}";
    }

    void Update()
    {
        
    }

    private void HighScoreView()
    {
        int highScore = PlayerPrefs.GetInt(PlayGameUI.HighScoreKey, 0);

        highScoreText.text = $"{highScore}";
    }


}
