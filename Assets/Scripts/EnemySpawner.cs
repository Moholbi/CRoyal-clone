using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;
    [SerializeField] float _spawnTimer;

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0f)
        {
            SpawnEnemy();
        }
    }

    //Verilen süre aralığında random bir zaman seçip geri sayar ve sayaç 0'a ulaştığında verilen düşmanlardan bir tanesini seçerek spawn'lar
    void SpawnEnemy()
    {
        int targetIndex = Random.Range(0, _enemies.Length);
        int randomSpawnRange = Random.Range(3, 7);

        Instantiate(_enemies[targetIndex], transform.position, Quaternion.identity);
        _spawnTimer = randomSpawnRange;
    }
}