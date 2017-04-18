using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomY : MonoBehaviour {

    // Use this for initialization
    public GameObject player2;
	void Start () {
        float posY = Random.Range(-4.5f, 5);
        player2.transform.position = new Vector3(7.63f, posY, 0.0f);
	}
	
}
