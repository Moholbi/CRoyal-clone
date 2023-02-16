using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCounterUI;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] public float waveCounter = 0f;

    void Update()
    {
        SetWaveText();
    }

    public void SetWaveText()
    {
        waveCounterUI.text = "Wave:" + enemySpawner.currentWave;
    }
}
