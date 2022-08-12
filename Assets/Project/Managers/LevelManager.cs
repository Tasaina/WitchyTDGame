using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<EnemyGoal> goals;
    private TurretPlaceholder currentPlaceholder;
    public TurretPlaceholder turretPlaceholderPrefab;

    void Start()
    {
        SceneManager.sceneLoaded += LoadEnemyGoals;
    }

    //TODO move to local object in level? Enemy grabs that gameobject on spawn?
    private void LoadEnemyGoals(Scene scene, LoadSceneMode mode)
    {
        goals = FindObjectsOfType<EnemyGoal>().ToList();
    }

    //TODO Move into turretmanager
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
    }

    public void DropPlaceholder()
    {
        Destroy(currentPlaceholder.gameObject);
        currentPlaceholder = null;
    }
}
