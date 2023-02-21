using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float _spawnTimer;
    string[] enemyTypes = { "RedKnight", "RedMage", "RedBird", "RedPriest" };
    private string _selectedUnit;
    [SerializeField] GameTimer gameTimer;

    int _minSpawnValue = 4;
    int _maxSpawnValue = 8;

    public int currentWave;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _spawnTimer = 3f;
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

    void SpawnEnemy()
    {
        //int targetIndex = Random.Range(0, enemyTypes.Length);
        int randomSpawnRange = Random.Range(_minSpawnValue, _maxSpawnValue);
        int targetIndex = 1;

        _spawnTimer = randomSpawnRange;

        if (targetIndex == 0)
        {
            SpawnKnight();
        }

        if (targetIndex == 1)
        {
            SpawnMage();
        }

        if (targetIndex == 2)
        {
            SpawnBird();
        }

        if (targetIndex == 3)
        {
            SpawnPriest();
        }

        _spawnTimer = randomSpawnRange;
    }

    void SpawnKnight()
    {
        _selectedUnit = "RedKnight";
        Damagable spawnedRedUnit = objectPooler.SpawnFromPool(_selectedUnit, transform.position, Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }

    void SpawnMage()
    {
        _selectedUnit = "RedMage";
        Damagable spawnedRedUnit = objectPooler.SpawnFromPool(_selectedUnit, transform.position, Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }

    void SpawnBird()
    {
        _selectedUnit = "RedBird";
        Damagable spawnedRedUnit = objectPooler.SpawnFromPool(_selectedUnit, transform.position, Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }

    void SpawnPriest()
    {
        _selectedUnit = "RedPriest";
        Damagable spawnedRedUnit = objectPooler.SpawnFromPool(_selectedUnit, transform.position, Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }
}