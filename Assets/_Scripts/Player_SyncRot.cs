using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_SyncRot : NetworkBehaviour {

	[SyncVar]
	private Quaternion syncPlayerRot;
	public Transform playerTransform;
	private float lerpRate = 15;

	private Quaternion lastRot;
	public float threshold;


	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		LerpRotation ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TransmitRotation ();
		//LerpRotation ();	
	}

	void LerpRotation(){
		if (!isLocalPlayer) {
			playerTransform.rotation = Quaternion.Lerp (playerTransform.rotation, syncPlayerRot, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvideRotationToServer(Quaternion playerRot){
		syncPlayerRot = playerRot;
		Debug.Log ("Command for Rot called");
	}

	[Client]
	void TransmitRotation(){
		if (isLocalPlayer && Quaternion.Angle(playerTransform.rotation, lastRot) > threshold) {
			CmdProvideRotationToServer (playerTransform.rotation);
			lastRot = playerTransform.rotation;
		}
	}
}
