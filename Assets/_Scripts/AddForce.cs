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

	private Vector3 acceleration;
    private Vector3 pos;
    private Vector3 velocity;

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

    /*void FixedUpdate () {
		acceleration = Vector3.zero;
        pos = transform.position;
		for (int i = 0; i < numPlanets; i++) {

            /*transform.right = rb1.velocity.normalized;
            //transform.right = 
			direction = attractedTo[i].transform.position - transform.position;
			distance = direction.magnitude;*/
            //forceOfAttraction = (gravitationalConst * mass1 * mass_planet[i]) / (distance * distance);
            //transform.Rotate(new Vector3(0,0,1) * 2 *  Time.deltaTime);
            //rb1.AddForce (forceOfAttraction * direction.normalized);
            //velocity = 0.5f * (gravitationalConst * mass_planet[i]) / (distance * distance);
            //transform.Translate(velocity * Time.deltaTime * direction.normalized);
            //transform.right = rb1.velocity.normalized;
            /*direction = attractedTo[i].transform.position - pos;
            distance = direction.magnitude;
            acceleration += (gravitationalConst * mass_planet[i] * direction.normalized) / (distance * distance);
        }
        velocity += acceleration * Time.fixedDeltaTime;
        transform.position += velocity * Time.fixedDeltaTime;
        Vector3 deltapos = pos - transform.position;
        transform.rotation.SetLookRotation(deltapos);
     }*/

    void Update()
    {
        //acceleration = Vector3.zero;
        for (int i = 0; i < numPlanets; i++)
        {
            transform.right = rb1.velocity;
            direction = attractedTo[i].transform.position - transform.position;
            distance = direction.magnitude;
            forceOfAttraction = (gravitationalConst * mass1 * mass_planet[i]) / (distance * distance);
            //transform.Rotate(new Vector3(0,0,1) * 2 *  Time.deltaTime);
            rb1.AddForce(forceOfAttraction * direction.normalized);
        }
    }
}
