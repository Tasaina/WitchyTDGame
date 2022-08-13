using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGoalHandler : MonoBehaviour
{
    [NonSerialized]
    public List<EnemyGoal> goals;
    
    void Start()
    {
        goals = GetComponentsInChildren<EnemyGoal>().ToList();
    }
}
