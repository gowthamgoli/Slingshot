using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour {
	public GameObject destination;
	public GameObject source;
	public GameObject logo;

    public GameObject shareButton;
    public GameObject helpButton;
    public GameObject rateButton;
    public GameObject logoutButton;

    public void openSoundMenu() {
		logo.SetActive (false);
		source.SetActive (false);
		destination.SetActive (true);
	}

    public void EnableButtons()
    {
        shareButton.SetActive(true);
        helpButton.SetActive(true);
        rateButton.SetActive(true);
        logoutButton.SetActive(true);
    }

	public void openInstructionMenu() {
		logo.SetActive (false);
		source.SetActive (false);
		destination.SetActive (true);
	}

	public void closeSoundMenu() {
		logo.SetActive (true);
		source.SetActive (false);
		destination.SetActive (true);
	}

	public void closeInstructionMenu() {
		logo.SetActive (true);
		source.SetActive (false);
		destination.SetActive (true);
        EnableButtons();
	}

	public void closeConnectionMenu() {
		// TODO:

		// leave room

		if (MultiplayerController.Instance.IsAuthenticated()){
			MultiplayerController.Instance.LeaveGame();
		}

		logo.SetActive (true);
		source.SetActive (false);
		destination.SetActive (true);

	}
}
