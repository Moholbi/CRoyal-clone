using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class EnemySpawnerPhoton : GlobalEventListener
{
    public float _spawnTimer;
    string[] enemyTypes = { "RedKnight", "RedMage", "RedBird", "RedPriest" };
    
    private string _selectedUnit;

    [SerializeField] GameObject redKnightPrefab;
    [SerializeField] GameObject redMagePrefab;
    [SerializeField] GameObject redBirdPrefab;
    [SerializeField] GameObject redPriestPrefab;

    int _minSpawnValue = 4;
    int _maxSpawnValue = 8;

    public override void SceneLoadLocalDone(string scene, IProtocolToken token)
    {
        //DoSomething;
    }

    void Start()
    {
        _spawnTimer = 3f;
    }

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

    void SpawnEnemy()
    {
        int targetIndex = Random.Range(0, enemyTypes.Length);
        int randomSpawnRange = Random.Range(_minSpawnValue, _maxSpawnValue);

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
    }

    void SpawnKnight()
    {
        _selectedUnit = "RedKnight";
        var spawnedRedUnit = BoltNetwork.Instantiate(redKnightPrefab, transform.position, Quaternion.identity);
        //AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }

    void SpawnMage()
    {
        _selectedUnit = "RedMage";
        var spawnedRedUnit = BoltNetwork.Instantiate(redMagePrefab, transform.position, Quaternion.identity);
        //AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }

    void SpawnBird()
    {
        _selectedUnit = "RedBird";
        var spawnedRedUnit = BoltNetwork.Instantiate(redBirdPrefab, transform.position, Quaternion.identity);
        //AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }

    void SpawnPriest()
    {
        _selectedUnit = "RedPriest";
        var spawnedRedUnit = BoltNetwork.Instantiate(redPriestPrefab, transform.position, Quaternion.identity);
        //AliveUnitHolder.RedUnitList.Add(spawnedRedUnit);
    }
}