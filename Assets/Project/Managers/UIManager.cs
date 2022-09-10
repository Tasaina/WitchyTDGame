using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public TurretUI turretUIPrefab;
    public TurretUI currentTurretUI;

    private void Start()
    {
        SceneManager.sceneLoaded += SetUpUI;
    }

    private void SetUpUI(Scene scene, LoadSceneMode mode)
    {
        currentTurretUI = Instantiate(turretUIPrefab);
        currentTurretUI.gameObject.SetActive(false);
    }

    public void ShowTurretUI(Turret turret)
    {
        if (currentTurretUI.Turret != null) currentTurretUI.Turret.rangeIndicator.Hide();
        turret.rangeIndicator.Show();
        currentTurretUI.gameObject.SetActive(true);
        currentTurretUI.Setup(turret);
    }
    public void HideTurretUI()
    {
        if (currentTurretUI == null) return;
        currentTurretUI.gameObject.SetActive(false);
        currentTurretUI.Turret.rangeIndicator.Hide();
    }
}
