using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;

    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0);
        if (health<=0) Destroy(gameObject);
    }

    public void GetHit(HitEffects effects)
    {
        health -= effects.Damage;
    }
}
