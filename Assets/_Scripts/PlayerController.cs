using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float vertSpeed;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

    private Touch touch;

    public Material[] spaceCraftMaterials;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)    //check for the first touch
            {
                //do nothing
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                if (transform.position.x < 0)
                    transform.Rotate(Vector3.forward * touch.deltaPosition.y * speed * Time.deltaTime);
                else
                    transform.Rotate(-Vector3.forward * touch.deltaPosition.y * speed * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                //do nothing
            }

            else
            {
                if(Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }
        }

        /*if (Input.GetKey ("up")) {
			//print ("up arrow key is held down");
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey ("down")) {
			//print ("down arrow key is held down");
			transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey ("w")) {
			//print ("up arrow key is held down");
			transform.Translate(Vector3.up * vertSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("s")) {
			//print ("down arrow key is held down");
			transform.Translate(-Vector3.up * vertSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetButton("Jump") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}*/
    }

    public void SetCarChoice(int carNum, bool isMultiplayer)
    {
        transform.FindChild("Player").GetComponent<Renderer>().material = spaceCraftMaterials[carNum - 1];
    }

}
