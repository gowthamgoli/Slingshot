using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	private GameObject[] attractedTo;
	public float gravitationalConst;

	private Rigidbody rb1;
	private Rigidbody[] rb_planet;

	private int numPlanets;
	private float mass1;
	private float[] mass_planet;

	//private Vector3 acceleration;

	private float forceOfAttraction, distance;

	private Vector3 direction, directionPerp;
	// Use this for initialization
	void Start () {
		attractedTo = GameObject.FindGameObjectsWithTag("Planet");
		numPlanets = attractedTo.Length;

		rb_planet = new Rigidbody[numPlanets];
		mass_planet = new float[numPlanets];

		rb1 = GetComponent<Rigidbody> ();
		mass1 = rb1.mass;

		for (int i = 0; i < numPlanets; i++) {
			rb_planet [i] = attractedTo [i].GetComponent<Rigidbody> ();
			mass_planet [i] = rb_planet [i].mass;
		}
		//rb2 = attractedTo.GetComponent<Rigidbody>();

		//mass2 = rb2.mass;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//acceleration = Vector3.zero;
		for (int i = 0; i < numPlanets; i++) {

			transform.right = rb1.velocity;
			direction = attractedTo[i].transform.position - transform.position;
			distance = direction.magnitude;
            forceOfAttraction = (gravitationalConst * mass1 * mass_planet[i]) / (distance * distance);
			//transform.Rotate(new Vector3(0,0,1) * 2 *  Time.deltaTime);
			rb1.AddForce (forceOfAttraction * direction.normalized);


		}

	}
}
