using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public RunManager RunManager { get; set; }
    public LevelManager LevelManager { get; set; }

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
        DontDestroyOnLoad(gameObject);
    }
}
