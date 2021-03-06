﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2DCarGame");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadWinScreen()
    {
        SceneManager.LoadScene("WinnerScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

}
