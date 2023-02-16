using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;
    [SerializeField] float _spawnTimer;
    [SerializeField] GameTimer gameTimer;

    int _minSpawnValue = 4;
    int _maxSpawnValue = 8;

    public int currentWave;

    void Start()
    {
        currentWave = 1;
    }

    void Update()
    {
        Timer();
        EnemyFrequency();
    }

    void Timer()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0f)
        {
            SpawnEnemy();
        }
    }

    void EnemyFrequency()
    {
        if (gameTimer.gameTimer < 40f)
        {
            _minSpawnValue = 6;
            _maxSpawnValue = 9;
            currentWave = 2;
        }

        if (gameTimer.gameTimer < 30f)
        {
            _minSpawnValue = 3;
            _maxSpawnValue = 6;
            currentWave = 3;
        }

        if (gameTimer.gameTimer < 20f)
        {
            _minSpawnValue = 1;
            _maxSpawnValue = 3;
            currentWave = 4;
        }
    }

    //Verilen süre aralığında random bir zaman seçip geri sayar ve sayaç 0'a ulaştığında verilen düşmanlardan bir tanesini seçerek spawn'lar
    void SpawnEnemy()
    {
        int targetIndex = Random.Range(0, _enemies.Length);
        int randomSpawnRange = Random.Range(_minSpawnValue, _maxSpawnValue);

        Instantiate(_enemies[targetIndex], transform.position, Quaternion.identity);
        _spawnTimer = randomSpawnRange;
    }


}