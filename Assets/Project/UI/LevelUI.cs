using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Turret turretToSpawn;

    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(SpawnTowerClicked);
    }

    private void SpawnTowerClicked()
    {
        GameManager.Instance.TurretManager.SpawnPlaceholder(turretToSpawn);
    }
}
