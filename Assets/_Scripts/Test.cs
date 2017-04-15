using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    // Use this for initialization
    public GameObject myCar;
	void Start () {
        Instantiate(myCar, Vector3.zero, Quaternion.identity);
	}
	
}
