using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("up")) {
			//print ("up arrow key is held down");
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey ("down")) {
			//print ("down arrow key is held down");
			transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetButton("Jump") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
