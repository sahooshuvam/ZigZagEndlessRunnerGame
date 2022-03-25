using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager: MonoBehaviour
{
    // Start is called before the first frame update
    public Button play;
    public Button instructions;
    public Button settings;
    //public Button instructionBack;
    public Button back;
    public GameObject instructionsPanel;
    public GameObject settingsPanel;
    public GameObject homePanel;
    void Start()
    {
        play.onClick.AddListener(Play);
        instructions.onClick.AddListener(Instructions);
        settings.onClick.AddListener(Settings);
        back.onClick.AddListener(Back);
    }

    // Update is called once per frame
   
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Instructions()
    {
        instructionsPanel.SetActive(true);
        homePanel.SetActive(false);
        back.gameObject.SetActive(true);
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
        homePanel.SetActive(false);
        back.gameObject.SetActive(true);
    }
    public void Back()
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        homePanel.SetActive(true);
        back.gameObject.SetActive(false);       
    }
   


}