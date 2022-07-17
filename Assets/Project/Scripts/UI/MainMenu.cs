using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button newGameButton;
    private Button settingsButton;
    private Button quitButton;

    void Start()
    {
        var buttons = GetComponentsInChildren<Button>();

        newGameButton = buttons.First(b=>b.name=="NewGameButton");
        newGameButton.onClick.AddListener(NewGame);

        settingsButton = buttons.First(b=>b.name=="SettingsButton");
        settingsButton.onClick.AddListener(OpenSettings);

        quitButton = buttons.First(b=>b.name=="QuitButton");
        quitButton.onClick.AddListener(Quit);
    }
    private void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OpenSettings()
    {
        SceneManager.LoadScene("GameSettingsScene");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
