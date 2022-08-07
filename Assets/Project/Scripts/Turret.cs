using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float attackDelay;
    
    public Bullet bulletPrefab;
    public float attackRange;
    public float baseAttackDelay;
    public float damage;
    public TurretRangeIndicator rangeIndicator;
    public List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        rangeIndicator.transform.localScale *= attackRange;
        rangeIndicator.Enter.AddListener(AddTarget); 
        rangeIndicator.Exit.AddListener(RemoveTarget);
    }

    private void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay > 0)  return; 
            
        if (enemies.Count != 0)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.Setup(this, enemies[0].transform);
            bullet.transform.position = transform.position;
            attackDelay = baseAttackDelay;
        }
    }

    private void AddTarget(Collider2D collider)
    {
        Console.WriteLine("ADD TARGET CALLED");
        var enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;

        enemies.Add(enemy);
    }
    private void RemoveTarget(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponent<Enemy>();

        enemies.Remove(enemy);
    }
   
}
