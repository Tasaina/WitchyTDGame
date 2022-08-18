using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelUI : MonoBehaviour
{
    public Turret turretToSpawn;
    private TextMeshProUGUI essenceText;
    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(SpawnTowerClicked);
        essenceText = GetComponentsInChildren<TextMeshProUGUI>().First(t=>t.name=="EssenceText");
    }
    private void Update()
    {
        essenceText.text = $"Essence: {GameManager.Instance.LevelManager.essence}";
    }
    private void SpawnTowerClicked()
    {
        GameManager.Instance.TurretManager.SpawnPlaceholder(turretToSpawn);
    }
}
