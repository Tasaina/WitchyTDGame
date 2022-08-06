using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
