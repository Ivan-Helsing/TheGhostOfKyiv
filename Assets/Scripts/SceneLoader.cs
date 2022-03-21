using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameObject popupMenu;
    

    private float pause = 0f;
    private float resume = 1f;

    private void GamePause()
    {
        if (!popupMenu.activeInHierarchy)
        {
            Time.timeScale = pause;
        }
    }

    private void GameResume()
    {
        if (popupMenu.activeInHierarchy)
        {
            Time.timeScale = resume;
        }
    }

    public void PopupActivate()
    {
        GamePause();
        popupMenu.SetActive(true);
        
    }

    public void PopupDeactivate()
    {
        GameResume();
        popupMenu.SetActive(false);
    }



    public void LoadPlayGameScene()
    {
        SceneManager.LoadScene("PlayGameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    public void LoadShedScene()
    {
        SceneManager.LoadScene("ShedScene");
    }


    public void WaitAndLoadStartMenu()
    {
        StartCoroutine(LoadStartMenuWithDelay());
    }

    private IEnumerator LoadStartMenuWithDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartMenuScene");
    }



    public void GameQuit()
    {
        Application.Quit();
    }
}
