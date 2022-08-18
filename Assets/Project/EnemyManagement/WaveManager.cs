using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public UnityEvent waveStart= new UnityEvent();
    private List<EnemySpawnpoint> enemySpawnpoints;
    [NonSerialized]
    public int maxWaves;
    [NonSerialized]
    public int currentWave;

    void Start()
    {
        currentWave = 1;
        SceneManager.sceneLoaded += LoadEnemySpawnpoints;
    }

    private void Update()
    {
        if (enemySpawnpoints != null && enemySpawnpoints.All(es => es.waveComplete) && FindObjectsOfType<Enemy>().Count()==0)
        {
            currentWave++;
            waveStart.Invoke();
        }
    }


    private void LoadEnemySpawnpoints(Scene scene, LoadSceneMode mode)
    {
        waveStart.Invoke();
        enemySpawnpoints = FindObjectsOfType<EnemySpawnpoint>().ToList();
        maxWaves = enemySpawnpoints.Select(es => es.waves).Max(ws=>ws.Max(w=>w.toWave));
    }
}
