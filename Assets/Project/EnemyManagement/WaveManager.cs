using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public float WaveTimer => waveTimer;

    public UnityEvent waveStart = new UnityEvent();
    private List<EnemySpawnpoint> enemySpawnpoints = new List<EnemySpawnpoint>();
    [NonSerialized]
    public int maxWaves;
    [NonSerialized]
    public int currentWave;
    public float baseWaveTimer;
    private NextWaveUI nextWaveUI;
    private float waveTimer;

    void Start()
    {
        SceneManager.sceneLoaded += LevelStart;
    }

    public void StartWave()
    {
        waveTimer = 0;
    }

    private void Update()
    {
        if (enemySpawnpoints.Count>0 && enemySpawnpoints.All(es => es.waveComplete) && FindObjectsOfType<Enemy>().Count()==0)
        {
            nextWaveUI.gameObject.SetActive(true);

            waveTimer -= Time.deltaTime;
            if (waveTimer > 0) return; 
            currentWave++;
            if (currentWave > maxWaves) currentWave = maxWaves;
            nextWaveUI.gameObject.SetActive(false);
            waveTimer = baseWaveTimer;
            waveStart.Invoke();
        }
    }

    private void LevelStart(Scene scene, LoadSceneMode mode)
    {
        nextWaveUI = FindObjectOfType<NextWaveUI>();
        enemySpawnpoints = FindObjectsOfType<EnemySpawnpoint>().ToList();

        maxWaves = enemySpawnpoints.Select(es => es.waves).Max(ws => ws.Max(w => w.toWave));

        currentWave = 0;
        waveTimer = baseWaveTimer;
        waveStart.Invoke();
    }
}
