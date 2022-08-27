
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
    public Button turretButtonPrefab;
    public GameObject turretButtonPanel;
    private TextMeshProUGUI essenceText;
    private TextMeshProUGUI waveText;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameManager.Instance.LevelManager;
        var turrets = levelManager.AvailableTurrets;
        foreach (var turret in turrets)
        {
            Button turretButton = Instantiate(turretButtonPrefab,turretButtonPanel.transform);
            turretButton.GetComponentsInChildren<TextMeshProUGUI>()[0].text = turret.name;
            turretButton.GetComponentsInChildren<TextMeshProUGUI>()[1].text = turret.purchaseCost.ToString();
        }

        essenceText = GetComponentsInChildren<TextMeshProUGUI>().First(t=>t.name=="EssenceText");
        waveText = GetComponentsInChildren<TextMeshProUGUI>().First(t => t.name == "WaveText");
        UpdateWaveText();
        GameManager.Instance.WaveManager.waveStart.AddListener(UpdateWaveText);
    }

    private void Update()
    {
        essenceText.text = $"Essence: {GameManager.Instance.LevelManager.essence}";
    }

    private void UpdateWaveText()
    {
        var waveManager = GameManager.Instance.WaveManager;
        waveText.text = $"Wave {waveManager.currentWave} / {waveManager.maxWaves}";
    }
}
