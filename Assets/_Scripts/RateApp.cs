using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateApp : MonoBehaviour {

	// Use this for initialization
	public void rateApp () {
		Application.OpenURL ("market://details?id=com.FlyingSpaghetti.Slingshot");
	}
}
