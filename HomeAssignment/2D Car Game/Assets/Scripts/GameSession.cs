using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int playerScore = 0;
    int playerhealth = 50;

    void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return playerScore;
    }
    public int GetHealth()
    {
        return playerhealth;
    }
    public void Health(int health)
    {
        playerhealth = health;
    }
    public void Score(int score)
    {
        playerScore += score;
        if (playerScore == 100)
        {
            FindObjectOfType<Level>().LoadWinScreen();
        }
    }

}
