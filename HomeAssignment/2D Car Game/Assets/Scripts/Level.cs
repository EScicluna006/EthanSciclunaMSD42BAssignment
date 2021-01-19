﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads the scene with name LaserDefender
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
