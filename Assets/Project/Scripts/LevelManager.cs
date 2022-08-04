using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<EnemyGoal> goals;

    void Start()
    {
        SceneManager.sceneLoaded += LoadEnemyGoals;
    }

    void Update()
    {
        
    }
    
    private void LoadEnemyGoals(Scene scene, LoadSceneMode mode)
    {
        goals = FindObjectsOfType<EnemyGoal>().ToList();
    }
}
