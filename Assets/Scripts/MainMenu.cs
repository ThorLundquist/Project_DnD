using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsPanel;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings() 
    {
        settingsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Shutting down...");
        Application.Quit();
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayIntro()
    {
        SceneManager.LoadScene(2);
    }
}
