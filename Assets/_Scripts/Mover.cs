using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

    public Camera mainCamera;
    public Camera secondaryCamera;

    void Start(){
        
		rb = GetComponent<Rigidbody>();
		//Debug.Log (transform.right);
		rb.velocity = transform.right * speed;
	}
}
