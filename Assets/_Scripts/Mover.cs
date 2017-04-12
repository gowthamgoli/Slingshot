using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

    public Slider speedSilder;

    //public Camera mainCamera;
    //public Camera secondaryCamera;

    void Start(){
        
		rb = GetComponent<Rigidbody>();

        speedSilder = GameObject.Find("Slider").GetComponent<Slider>();
		rb.velocity = transform.right * speed * speedSilder.value * 0.02f;
	}
}
