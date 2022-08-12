using Assets.Project.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField]
    public List<WaveInformation> waves = new List<WaveInformation>();
    
    [NonSerialized]
    public int enemiesLeftInWave;
    [NonSerialized]
    public int currentEnemy;

    private int spawnDelay;
    private WaveInformation currentWaveInformation;
    private WaveManager waveManager;
    private bool active;

    private void Start()
    {
        waveManager = GameManager.Instance.WaveManager;
    }

    void Update()
    {
        // spon aynemees
    }

    public void WaveStart()
    {
        currentWaveInformation = waves.FirstOrDefault(w => waveManager.currentWave >= w.fromWave && waveManager.currentWave <= w.toWave);
        active = currentWaveInformation != null;
    }

    private void SpawnEnemy() { 
    
    }
}
