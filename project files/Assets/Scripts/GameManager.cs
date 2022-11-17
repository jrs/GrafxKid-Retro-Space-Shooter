using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject StartText;
    public GameObject GameOverText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI PlayerLivesText;
    public int Score;
    public int PlayerLives;


    private bool _isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        _isGameActive = true;
        PlayerLives = 9;
        Score = 0;
    }

    public void GameOver()
    {
        _isGameActive = false;
    }

    public void UpdateScore(int amount)
    {
        ScoreText.text = (Score += amount).ToString();
    }

    public void UpdatePlayerLives(int amount)
    {
        PlayerLivesText.text = "<sprite=" + (PlayerLives -= amount).ToString() + ">"; 
    }
}
