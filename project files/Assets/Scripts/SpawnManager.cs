using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    private float _startDelay = 2;
    private float _repeatRate = 2;
    private float _xRange = 8;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemyPrefab", _startDelay, _repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomEnemyPrefab()
    {
        int index = Random.Range(0, EnemyPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-_xRange, _xRange), transform.position.y);

        Instantiate(EnemyPrefabs[index], spawnPos, EnemyPrefabs[index].transform.rotation);
    }
}
