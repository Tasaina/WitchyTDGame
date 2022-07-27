using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float attackRange;
    public TurretRangeIndicator rangeIndicator;
    
    void Start()
    {
        rangeIndicator.Enter.AddListener(AddTarget); 
        rangeIndicator.Exit.AddListener(RemoveTarget);
    }
    private void Update()
    {

    }

    private void AddTarget(Collider2D collider)
    {

    }
    private void RemoveTarget(Collider2D collider)
    {

    }
   
}
