using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public int candy; // overarching (in-world) currency

    public void NextLevel()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    public void GoToHub()
    {
        SceneManager.LoadScene("HubScene");
    }
}
