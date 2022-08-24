using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretRangeIndicator : MonoBehaviour
{
    public UnityEvent<Collider2D> Enter;
    public UnityEvent<Collider2D> Stay;
    public UnityEvent<Collider2D> Exit;

    private void Start()
    {
        ToggleVisibility();
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

    public void ToggleVisibility()
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

    public void Hide()
    {
        GetComponent<Renderer>().enabled = false;
    }

    public void Show()
    {
        GetComponent<Renderer>().enabled = true;
    }
}
