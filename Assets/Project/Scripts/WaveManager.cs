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
        SceneManager.sceneLoaded += LoadEnemySpawnpoints;
    }

    private void LoadEnemySpawnpoints(Scene scene, LoadSceneMode mode)
    {
        enemySpawnpoints  = FindObjectsOfType<EnemySpawnpoint>().ToList();
        maxWaves = enemySpawnpoints.Select(es => es.waves).Max(ws=>ws.Max(w=>w.toWave));
    }
    private void Update()
    {

    }
}
