using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

    private void Update()
    {
        
    }



    public void LoadPlayGameScene()
    {
        SceneManager.LoadScene("PlayGameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
        //StartCoroutine(PauseGameAndLoadStartMenu());   // add only when make game Pause.
    }

    public void LoadShedScene()
    {
        SceneManager.LoadScene("ShedScene");
    }


    public void WaitAndLoadStartMenu()
    {
        StartCoroutine(PauseGameAndLoadStartMenu());
    }

        //Find how to pause game before scenechanging.
        private IEnumerator PauseGameAndLoadStartMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartMenuScene");
    }




    public void GameQuit()
    {
        Application.Quit();
    }


}
