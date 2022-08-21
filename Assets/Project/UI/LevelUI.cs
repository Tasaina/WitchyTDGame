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
    private TextMeshProUGUI waveText;
    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(SpawnTowerClicked);
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

    private void SpawnTowerClicked()
    {
        GameManager.Instance.TurretManager.SpawnPlaceholder(turretToSpawn);
    }
}
