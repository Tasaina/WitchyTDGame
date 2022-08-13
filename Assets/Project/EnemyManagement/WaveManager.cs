using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
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
        if (enemySpawnpoints.All(es => es.enemiesLeftInWave == 0) && FindObjectsOfType<Enemy>().Count()==0)
        {
            currentWave++;
            //TODO change to unityevent
            enemySpawnpoints.ForEach(es => es.WaveStart());
        }
    }

    private void LoadEnemySpawnpoints(Scene scene, LoadSceneMode mode)
    {
        enemySpawnpoints = FindObjectsOfType<EnemySpawnpoint>().ToList();
        enemySpawnpoints.ForEach(es => es.WaveStart());
        maxWaves = enemySpawnpoints.Select(es => es.waves).Max(ws=>ws.Max(w=>w.toWave));
    }
}
