using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    private int pathId;
    public List<EnemyGoal> activeGoals = new List<EnemyGoal>();
    private EnemyGoal goal;

    private void Start()
    {
       
    }

    public void Setup(int pathId)
    {
        this.pathId = pathId;
        activeGoals = FindObjectOfType<EnemyGoalHandler>().goals.Where(g => g.pathId == pathId || g.pathId == 0).ToList();
        SetNewGoal(FindNextGoal());
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

        HitGoal(hitGoal);
    }

    private void HitGoal(EnemyGoal hitGoal)
    {
        if (hitGoal.IsFinal)
        {
            GameManager.Instance.LevelManager.TakeDamage(1);
            Destroy(gameObject);
        }
        if (hitGoal.forcedNextGoal!=null)
        {
            SetNewGoal(hitGoal.forcedNextGoal);
            return;
        } 
        SetNewGoal(FindNextGoal());
    }

    public EnemyGoal FindNextGoal()
    {
        return activeGoals.OrderBy(g => Vector3.Distance(transform.position, g.transform.position)).First();
    }

    private void SetNewGoal(EnemyGoal newGoal)
    {
        goal = newGoal;
        activeGoals.Remove(newGoal);
    }



    public void GetHit(HitEffects effects)
    {
        health -= effects.Damage;
    }

}
