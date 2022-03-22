using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneManager : MonoBehaviour
{
    public Button playButton;
    public Button instructions;
    public Button settings;
    public Button instructionBack;
    public Button settingBack;
    public GameObject instructionsPanel;
    public GameObject settingsPanel;
    public GameObject menuPanel;
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        instructions.onClick.AddListener(Instructions);
        settings.onClick.AddListener(Settings);
        instructionBack.onClick.AddListener(InstructionBack);
        settingBack.onClick.AddListener(SettingsBack);
    }

    // Update is called once per frame

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Instructions()
    {
        instructionsPanel.SetActive(true);
        menuPanel.SetActive(false);
        instructionBack.gameObject.SetActive(true);
    }
    public void Settings()
    {

        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
        //settingBack.gameObject.SetActive(true);
    }
    public void InstructionBack()
    {
        instructionsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void SettingsBack()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

}
