using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPlayGameScene()
    {
        SceneManager.LoadScene("PlayGameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
        //StartCoroutine(PauseGameAndLoadStartMenu());   // add only when make game Pause.
    }

    //Find how to pause game before scenechanging.
    private IEnumerator PauseGameAndLoadStartMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("StartMenuScene");
    }
}
