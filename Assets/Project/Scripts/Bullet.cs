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
        
    }
}
