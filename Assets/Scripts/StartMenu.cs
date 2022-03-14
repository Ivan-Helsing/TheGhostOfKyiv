using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;


    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt(PlayGameUI.HighScoreKey, 0);

        highScoreText.text = $"High Score: {highScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
