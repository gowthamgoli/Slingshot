using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour {

    public Material[] spaceCraftMaterials;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCarNumber(int carNum)
    {
        transform.FindChild("Player").GetComponent<Renderer>().material = spaceCraftMaterials[carNum - 1];
    }

    public void SetCarInformation(float rotZ)
    {
        //transform.position = new Vector3(posX, posY, 0);
        transform.rotation = Quaternion.Euler(0, 0, 180f-rotZ);
        // We're going to do nothing with velocity.... for now
    }
}
