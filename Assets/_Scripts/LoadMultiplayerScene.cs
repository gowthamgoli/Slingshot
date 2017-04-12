using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMultiplayerScene : MonoBehaviour {

	public void load () 
	{
		Debug.Log("Pressed multi");
		SceneManager.LoadScene(1);
	}
}
