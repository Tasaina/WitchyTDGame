using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private TurretPlaceholder currentPlaceholder;
    public TurretPlaceholder turretPlaceholderPrefab;

    public void SpawnPlaceholder(Turret turretToSpawn)
    {
        if (currentPlaceholder != null) return;
        currentPlaceholder = Instantiate(turretPlaceholderPrefab);
        currentPlaceholder.Setup(turretToSpawn);
    }

    public void SpawnTurret()
    {
        if (currentPlaceholder == null) return;
        var turret = Instantiate(currentPlaceholder.turret);
        turret.transform.position = currentPlaceholder.transform.position;
        DropPlaceholder();
        GameManager.Instance.LevelManager.essence -= turret.purchaseCost;
    }

    public void DropPlaceholder()
    {
        Destroy(currentPlaceholder.gameObject);
        currentPlaceholder = null;
    }
}
