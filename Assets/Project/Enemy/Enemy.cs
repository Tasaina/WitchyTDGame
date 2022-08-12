using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    private List<EnemyGoal> activeGoals = new List<EnemyGoal>();
    private EnemyGoal goal;

    private void Start()
    {
        activeGoals = GameManager.Instance.LevelManager.goals.ToList();
        SetNewGoal();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, goal.transform.position, speed * Time.deltaTime);
        if (health<=0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitGoal = collision.GetComponent<EnemyGoal>();
        if (hitGoal == null) return;

        if (hitGoal.IsFinal)
        {
            GameManager.Instance.RunManager.TakeDamage(1);
            Destroy(gameObject);
        }
        activeGoals.Remove(hitGoal);
        SetNewGoal();
    }

    public void GetHit(HitEffects effects)
    {
        health -= effects.Damage;
    }

    private void SetNewGoal()
    {
        goal = activeGoals.OrderBy(g => Vector3.Distance(transform.position, g.transform.position)).First();
    }
}
