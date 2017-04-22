using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject pauseButton;
	public GameObject pauseMenu;
    //public GameObject MainMenuButton;

    void Start() {
        //pauseMenu.SetActive(false);
    }

	public void showPauseMenu() {
        //Debug.Log("pressed pause");
		pauseMenu.SetActive (true);
		pauseButton.SetActive (false);
	}

	public void hidePauseMenu() {
		pauseMenu.SetActive (false);
		pauseButton.SetActive (true);
	}

    public void MainMenuButton()
    {
        //MultiplayerController.Instance.LeaveGame();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        MultiplayerController.Instance.LeaveGame();
        SceneManager.LoadScene(0);
    }


}
