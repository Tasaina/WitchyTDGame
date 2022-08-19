using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float FireRate => 1;
    public int UpgradeCost => (int)(10+(baseUpgradeCost*level));

    public float baseUpgradeCost;
    public int level;
    public Bullet bulletPrefab;
    public float attackRange;
    public float baseAttackDelay;
    public float damage;
    public TurretRangeIndicator rangeIndicator;
    public List<Enemy> enemies = new List<Enemy>();
    
    private float attackDelay;

    void Start()
    {
        rangeIndicator.transform.localScale *= attackRange;
        rangeIndicator.Enter.AddListener(AddTarget); 
        rangeIndicator.Exit.AddListener(RemoveTarget);
    }

    private void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay > 0) return;
            
        if (enemies.Count != 0)
        {
            var bullet = Instantiate(bulletPrefab, transform);
            bullet.Setup(this, enemies[0].transform);
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
        var enemy = collider.gameObject.GetComponent<Enemy>();

        enemies.Remove(enemy);
    }

    public void Upgrade()
    {
        level += 1;
        damage = (int)(damage*1.1);
        baseAttackDelay *= .9f;
        attackRange = (int)(attackRange * 1.1);
        rangeIndicator.transform.localScale *= 1.1f;
    }
}
