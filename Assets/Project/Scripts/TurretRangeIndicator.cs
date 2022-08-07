using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretRangeIndicator : MonoBehaviour
{
    public UnityEvent<Collider2D> Enter;
    public UnityEvent<Collider2D> Stay;
    public UnityEvent<Collider2D> Exit;
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enter.Invoke(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Stay.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Exit.Invoke(collision);
    }
}
