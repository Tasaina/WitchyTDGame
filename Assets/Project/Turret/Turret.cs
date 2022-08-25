using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{
    public float FireRate => 1/baseAttackDelay;
    public int UpgradeCost => (int)(10+(baseUpgradeCost*level));

    public Sprite shopIcon;
    public int purchaseCost;
    public float baseUpgradeCost;
    public int level;
    public Bullet bulletPrefab;
    public float attackRange;
    public float baseAttackDelay;
    public float damage;
    public TurretRangeIndicator rangeIndicator;
    public List<Enemy> enemies = new List<Enemy>();
    
    private float attackDelay;
    private UIManager uiManager;

    void Start()
    {
        uiManager = GameManager.Instance.UIManager;
        rangeIndicator.transform.localScale *= attackRange;
        rangeIndicator.Enter.AddListener(AddTarget); 
        rangeIndicator.Exit.AddListener(RemoveTarget);
        rangeIndicator.Hide();
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
        damage = (int)(damage+1 * 1.1);
        baseAttackDelay *= .9f;
        attackRange = attackRange * 1.1f;
        rangeIndicator.transform.localScale *= 1.1f;
    }

    private void OnMouseDown()
    {
        uiManager.ShowTurretUI(this);
    }
}
