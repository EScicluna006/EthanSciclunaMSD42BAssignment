using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTxt : MonoBehaviour
{
    Text healthText;
    GameSession gameSession;


    void Start()
    {
        healthText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        healthText.text = gameSession.GetHealth().ToString();
    }
}
