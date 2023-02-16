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
            _minSpawnValue = 3;
            _maxSpawnValue = 7;
            Debug.Log("< 40");
        }

        if (gameTimer.gameTimer < 30f)
        {
            _minSpawnValue = 2;
            _maxSpawnValue = 5;
            Debug.Log("< 30");
        }

        if (gameTimer.gameTimer < 20f)
        {
            _minSpawnValue = 1;
            _maxSpawnValue = 3;
            Debug.Log("< 20");
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