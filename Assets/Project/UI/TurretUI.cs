using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    public Turret Turret { get; private set; }

    private Button upgradeTurretButton;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI levelText;
    private TextMeshProUGUI attackText;
    private TextMeshProUGUI fireRateText;
    private TextMeshProUGUI rangeText;
    private TextMeshProUGUI upgradeCostText;

    void Start()
    {
        var buttons = GetComponentsInChildren<Button>();
        upgradeTurretButton = buttons.First(b=>b.name=="UpgradeButton");
        upgradeTurretButton.onClick.AddListener(Upgrade);

        var texts = GetComponentsInChildren<TextMeshProUGUI>();
        nameText = texts.First(t => t.name == "NameText");
        levelText = texts.First(t => t.name == "LevelText");
        attackText = texts.First(t => t.name == "AttackText");
        fireRateText = texts.First(t => t.name == "FireRateText");
        rangeText = texts.First(t => t.name == "RangeText");
        upgradeCostText = texts.First(t => t.name == "UpgradeCostText");

        UpdateTexts();
    }

    public void Setup(Turret turret)
    {
        Turret = turret;
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        nameText.text = Turret.name;
        levelText.text = $"Level {Turret.level+1}";
        attackText.text = $"Damage {Turret.damage}";
        fireRateText.text = $"Firerate {Turret.FireRate}";
        rangeText.text = $"Range {Turret.attackRange}";
        upgradeCostText.text = $"{Turret.UpgradeCost}";
    }

    private void Upgrade()
    {
        var levelManager = GameManager.Instance.LevelManager;
        if (levelManager.essence < Turret.UpgradeCost) return;
        levelManager.essence -= Turret.UpgradeCost;
        Turret.Upgrade();
        UpdateTexts();
    }
}
