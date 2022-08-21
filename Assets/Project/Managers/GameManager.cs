using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public RunManager RunManager { get; private set; }
    public LevelManager LevelManager { get; private set; }
    public WaveManager WaveManager { get; private set; }
    public TurretManager TurretManager { get; private set; }
    public UIManager UIManager { get; private set; }

    void Awake()
    {
        if (_instance!=null)
        {
            Debug.LogWarning("GameManager already set!");
            return;
        }
        _instance = this;
        RunManager = GetComponent<RunManager>();
        LevelManager = GetComponent<LevelManager>();
        WaveManager = GetComponent<WaveManager>();
        TurretManager = GetComponent<TurretManager>();
        UIManager = GetComponent<UIManager>();
        DontDestroyOnLoad(gameObject);
    }
}
