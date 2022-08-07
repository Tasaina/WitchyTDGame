using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Turret turret;
    private Transform target;
    public float speed;

    public void Setup(Turret turret, Transform target)
    {
        this.turret = turret;
        this.target = target;
    }

    private void Update()
    {
        if (target==null) Destroy(gameObject);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy == null) return;

        Destroy(gameObject);
        var effects = new HitEffects() { Damage = turret.damage };
        enemy.GetHit(effects);
    }
}
