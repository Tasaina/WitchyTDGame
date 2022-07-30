using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float attackRange;
    public float baseAttackDelay;
    private float attackDelay;
    public TurretRangeIndicator rangeIndicator;
    public List<Enemy> enemies = new List<Enemy>();
    
    void Start()
    {
        rangeIndicator.Enter.AddListener(AddTarget); 
        rangeIndicator.Exit.AddListener(RemoveTarget);
    }
    private void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay >= 0) { return; }
            
        if (enemies.Count != 0)
        {
            Instantiate(bulletPrefab);
            attackDelay = baseAttackDelay;
        }
    }

    private void AddTarget(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;

        enemies.Add(enemy);
    }
    private void RemoveTarget(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponent<Enemy>();//check out later//
        if (enemy == null) return;

        enemies.Remove(enemy);
    }
   
}
