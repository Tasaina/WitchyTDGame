using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int essence;
    private int currentHealth;

    [SerializeField]
    private int maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void GainEssence(int essenceGain)
    {
        essence += essenceGain;
    }
}
