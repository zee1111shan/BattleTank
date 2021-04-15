using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject StartPanel;

    public GameObject GamePanel;

    public GameObject GameOverPanel;

    public Text WonText;

    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnGameStateChange += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartBtn()
    {
        GameManager.current.CurrentState=GameState.Game;
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void GameOver()
    {
        if (GameManager.current.CurrentState == GameState.GameOver)
        {
            GamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }

        var players = FindObjectsOfType(typeof(Player));
        int score = 0;
        foreach (var player in players as Player[])
        {

            score += player.Health;
            if (player.Health > 0)
            {
                WonText.text = player.Color + " Won";
                score += player.MaxHealth;
            }
        }

        ScoreText.text = "Score: " + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
