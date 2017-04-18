using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler_Offline : MonoBehaviour {

    public GameObject menuPanel;
    //public GameObject pauseButton;

    public void PauseButton()
    {
        menuPanel.SetActive(true);
    }

    public void QuitButton() {
        SceneManager.LoadScene(0);
    }

    public void RefreshButton() {
        SceneManager.LoadScene(2);
    }

    public void ResumeButton() {
        menuPanel.SetActive(false);
    }
}
