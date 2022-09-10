using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public List<Turret> AvailableTurrets => availableTurrets.ToList();

    public int essence;
    [SerializeField]
    private List<Turret> availableTurrets = new List<Turret>();
    private int currentHealth;
    private UIManager uiManager;

    [SerializeField]
    private int maxHealth;

    void Start()
    {
        uiManager = GameManager.Instance.UIManager;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) LeftClicked();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameManager.Instance.RunManager.GoToHub();
        }
    }

    public void GainEssence(int essenceGain)
    {
        essence += essenceGain;
    }
    private void LeftClicked()
    {
        var eventSystem = EventSystem.current;
        if (eventSystem.currentSelectedGameObject != null)
        {
            var button = eventSystem.currentSelectedGameObject.GetComponent<Button>();
            if (button != null) return;
        }

        var anyTurret = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), .03f).
                        Where(c => c.GetComponent<Turret>()).
                        Any();
        if (anyTurret) return;
        
        uiManager.HideTurretUI();
    }
}
