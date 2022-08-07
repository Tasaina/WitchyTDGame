using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Turret turretToSpawn;
    public TurretPlaceholder turretPlaceholderPrefab;

    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(SpawnTowerClicked);
    }

    private void SpawnTowerClicked()
    {
        var turretPlaceholder = Instantiate(turretPlaceholderPrefab);
        turretPlaceholder.Setup(turretToSpawn);
    }
}
