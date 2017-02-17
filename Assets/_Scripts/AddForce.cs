using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	private GameObject attractedTo;
	public float gravitationalConst;

	private Rigidbody rb1, rb2;

	private float mass1, mass2;
	private float forceOfAttraction, distance;

	private Vector3 direction;
	// Use this for initialization
	void Start () {
		attractedTo = GameObject.Find ("Planet");
		rb1 = GetComponent<Rigidbody> ();
		rb2 = attractedTo.GetComponent<Rigidbody>();
		mass1 = rb1.mass;
		mass2 = rb2.mass;
	}

	// Update is called once per frame
	void Update () {
		direction = attractedTo.transform.position - transform.position;
		distance = direction.magnitude;
		Debug.Log ("distance: " + distance);
		forceOfAttraction = (gravitationalConst * mass1 * mass2) / (distance * distance);
		Debug.Log ("force: " + forceOfAttraction);
		rb1.AddRelativeForce (forceOfAttraction * direction.normalized);
		
	}
}
