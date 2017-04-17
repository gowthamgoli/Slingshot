using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour {
	public GameObject destination;
	public GameObject source;
	public GameObject logo;

	public void openSoundMenu() {
		logo.SetActive (false);
		source.SetActive (false);
		destination.SetActive (true);
	}

	public void closeSoundMenu() {
		logo.SetActive (true);
		source.SetActive (false);
		destination.SetActive (true);
	}

	public void closeConnectionMenu() {
		// TODO:

		// leave room
		MultiplayerController.Instance.LeaveGame();

		logo.SetActive (true);
		source.SetActive (false);
		destination.SetActive (true);

	}
}
