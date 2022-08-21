using Assets.Project.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using URandom = UnityEngine.Random;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField]
    public List<WaveInformation> waves = new List<WaveInformation>();
    
    public int enemiesLeftInWave => currentWaveInformation.spawnsLeft;
    public bool waveComplete => currentWaveInformation==null ? true : currentWaveInformation.spawnsLeft<=0;

    [NonSerialized]
    public int currentEnemy;

    private float spawnDelay;
    private WaveInformation currentWaveInformation;
    private WaveManager waveManager;
    private bool active;
    private void Awake()
    {
        waveManager = GameManager.Instance.WaveManager;
    }

    private void Start()
    {
        waveManager.waveStart.AddListener(WaveStart);
    }

    void Update()
    {
        if (!active) return;
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0)
        {
            //REFACTOR
            if (currentWaveInformation.spawnsLeft == 0)
            {
                active = false;
                return;
            }
            SpawnEnemy();
        }
    }

    public void WaveStart()
    {
        currentWaveInformation = waves.FirstOrDefault(w => waveManager.currentWave >= w.fromWave && waveManager.currentWave <= w.toWave);
        currentWaveInformation.spawnsLeft = currentWaveInformation.totalSpawns;
        active = currentWaveInformation != null;
    }

    private void SpawnEnemy() {
        var enemies = currentWaveInformation.potentialEnemies;
        var enemyToSpawn = enemies[URandom.Range(0, enemies.Count)];
        var enemy = Instantiate(enemyToSpawn, transform);
        enemy.Setup(currentWaveInformation.pathId);

        currentEnemy++;
        currentWaveInformation.spawnsLeft--;

        spawnDelay = currentWaveInformation.baseSpawnDelay;
    }
}
