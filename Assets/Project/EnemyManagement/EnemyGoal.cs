using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    public bool IsFinal => _isFinal;
    public EnemyGoal forcedNextGoal;
    public int pathId;

    [SerializeField]
    private bool _isFinal;
}
