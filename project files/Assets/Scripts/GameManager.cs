using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Config")]
    [SerializeField] private bool _isGameActive;
    public int Score;

    [Header("Game UI")]
    public GameObject StartText;
    public GameObject GameOverText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI PlayerLivesText;
    public Slider PowerSlider;

    [Header("Player Info")]
    public int PlayerLives = 3;
    public int PlayerPower = 10;
    public int PlayerPowerAmount = 10;
    public GameObject PlayerPowerupPrefab;

    [Header("Enemy Info")]
    public GameObject[] EnemyPrefabs;
    private float _xRange = 8;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = Score.ToString();
        PlayerLivesText.text = "<sprite=" + PlayerLives.ToString() + ">";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLives <= 0 || PlayerPowerAmount <= 0) 
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        StartText.SetActive(false);
        _isGameActive = true;
        //PlayerLives = 3;
        //Score = 0;
        //ScoreText.text = Score.ToString();
        //PlayerLivesText.text = "<sprite=" + PlayerLives.ToString() + ">";
        StartCoroutine(EnemySpawner());
        StartCoroutine(PowerCountDownTimer());
    }

    public bool IsGameAcitve()
    {
        return _isGameActive;
    }

    public void GameOver()
    {
        _isGameActive = false;
        GameOverText.SetActive(true);
        StartCoroutine(RestartGame());
    }

    public void UpdateScore(int amount)
    {
        ScoreText.text = (Score += amount).ToString();
    }

    public void UpdatePlayerLives(int amount)
    {
        PlayerLivesText.text = "<sprite=" + (PlayerLives -= amount).ToString() + ">"; 
    }

    public void UpdatePlayerPower(int amount)
    {
        if (PlayerPower > PlayerPowerAmount)
        {
            PlayerPowerAmount += amount;
            SetPowerSlider(PlayerPowerAmount);
        }
    }

    void SetPowerSlider(int amount)
    {
        PowerSlider.value = amount;
    }

    private void SpawnPlayerPowerPrefab()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-_xRange, _xRange), transform.position.y);
        Instantiate(PlayerPowerupPrefab, spawnPos, PlayerPowerupPrefab.transform.rotation);
    }

    private void SpawnRandomEnemyPrefab()
    {
        int index = Random.Range(0, EnemyPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-_xRange, _xRange), transform.position.y);

        Instantiate(EnemyPrefabs[index], spawnPos, EnemyPrefabs[index].transform.rotation);
    }

    IEnumerator EnemySpawner()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(2f);
            SpawnRandomEnemyPrefab();
            SpawnPlayerPowerPrefab();
        }
    }

    IEnumerator PowerCountDownTimer()
    {
        while(_isGameActive)
        {
            yield return new WaitForSeconds(5);
            PlayerPowerAmount--;
            SetPowerSlider(PlayerPowerAmount);
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
