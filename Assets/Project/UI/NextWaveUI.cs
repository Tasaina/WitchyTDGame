using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveUI : MonoBehaviour
{
    private TextMeshProUGUI waveTimer;
    private Button nextWaveButton;
    private WaveManager waveManager;
    void Start()
    {
        waveManager = GameManager.Instance.WaveManager;
        waveTimer = GetComponentsInChildren<TextMeshProUGUI>().First(t => t.name == "WaveTimerText");
        nextWaveButton = GetComponentsInChildren<Button>().First(b => b.name == "NextWaveButton");
        nextWaveButton.onClick.AddListener(NextWave);
    }

    private void NextWave()
    {
        waveManager.waveTimer = 0;
        gameObject.SetActive(false);
    }

    void Update()
    {
        waveTimer.text = $"Wave starts in: {Math.Round(waveManager.waveTimer,1)}";
    }
}
