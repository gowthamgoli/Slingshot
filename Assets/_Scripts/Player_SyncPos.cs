using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[NetworkSettings(channel=0, sendInterval = 0.1f)]
public class Player_SyncPos : NetworkBehaviour {

	//Automatically the server will transmit this value to all client when syncPos changes
	[SyncVar(hook="SyncPositionValues")]
	private Vector3 syncPos;

	public Transform myTransform;
	private float lerpRate = 15;
	private float normalLerpRate = 18;
	private float fasterLerpRate = 27;

	private Vector3 lastPos;
	public float threshold;

	private List<Vector3> syncPosList = new List<Vector3> ();
	[SerializeField] private bool useHistoricalLerping = false; 

	private float closeEnough = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		LerpPosition ();
	}

	void FixedUpdate () {
		TransmitPosition ();
		//LerpPosition ();
	}

	void LerpPosition(){
		if (!isLocalPlayer) {
			if (useHistoricalLerping) {
				HistoricalLerping ();
			} else {
				OrdinaryLerping ();
			}

		}
	}

	//Sent to the server. Client is telling the server to run this command (only on the server) and the client can supply a param
	[Command]
	void CmdProvidePositionToServer(Vector3 pos){
		syncPos = pos;
		Debug.Log ("Command for pos called");
	}

	//Only Clients call this function
	[ClientCallback]
	void TransmitPosition(){
		if (isLocalPlayer && Vector3.Distance(myTransform.position, lastPos) > threshold) {
			CmdProvidePositionToServer (myTransform.position);
			lastPos = myTransform.position;
		}
	}

	[Client]
	void SyncPositionValues(Vector3 latestPos){
		syncPos = latestPos;
		syncPosList.Add (syncPos);
	}

	void OrdinaryLerping(){
		myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
	}

	void HistoricalLerping(){
		if (syncPosList.Count > 0) {
			myTransform.position = Vector3.Lerp (myTransform.position, syncPosList[0], Time.deltaTime * lerpRate);
			if(Vector3.Distance(myTransform.position, syncPosList[0]) <  closeEnough){
				syncPosList.RemoveAt (0);
			}
			Debug.Log (syncPosList.Count.ToString ());
		}
	}

}
