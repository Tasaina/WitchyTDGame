using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public UnityEvent waveStart = new UnityEvent();
    private List<EnemySpawnpoint> enemySpawnpoints = new List<EnemySpawnpoint>();
    [NonSerialized]
    public int maxWaves;
    [NonSerialized]
    public int currentWave;
    [NonSerialized]
    public float waveTimer;
    public float baseWaveTimer;
    private NextWaveUI nextWaveUI;

    void Start()
    {
        currentWave = 0;
        waveTimer = baseWaveTimer;
        SceneManager.sceneLoaded += LoadEnemySpawnpoints;
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

    private void LoadEnemySpawnpoints(Scene scene, LoadSceneMode mode)
    {
        waveStart.Invoke();
        nextWaveUI = FindObjectOfType<NextWaveUI>();
        enemySpawnpoints = FindObjectsOfType<EnemySpawnpoint>().ToList();
        maxWaves = enemySpawnpoints.Select(es => es.waves).Max(ws=>ws.Max(w=>w.toWave));
    }
}
