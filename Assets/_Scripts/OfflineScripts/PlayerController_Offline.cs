using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Offline : MonoBehaviour {

    public float speed;
    public float vertSpeed;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    private Touch touch;

    public AudioSource shoot;
    //public GameObject Rotator;
    //public GameObject PowerSlider;

    private Slider speedSilder;
    public GameObject menuPanel;
    // Use this for initialization
    void Start () {
        menuPanel.SetActive(false);
	}

    void Update()
    {

        if (!menuPanel.active)
        {

            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)    //check for the first touch
                {
                    //do nothing
                }

                else if (touch.phase == TouchPhase.Moved)
                {
                    if (touch.position.x < (Screen.width / 2) && touch.position.x > (Screen.width / 8))
                    {
                        transform.Translate(Vector3.up * touch.deltaPosition.y * 2.5f * Time.deltaTime, Space.World);
                        // initially, the temporary vector should equal the player's position
                        Vector3 clampedPosition = transform.position;
                        // Now we can manipulte it to clamp the y element
                        clampedPosition.y = Mathf.Clamp(transform.position.y, -5f, 5f);
                        // re-assigning the transform's position will clamp it
                        transform.position = clampedPosition;
                    }
                }
                else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
                {
                    //do nothing
                }

                else
                {
                    if (touch.position.x > (Screen.width / 2) && touch.position.y > (Screen.height / 8))
                    {
                        //spawnText.text = gameController.getPlayerTurn().ToString();
                        //if (gameController.getPlayerTurn() == myTurn && gameController.getNumBolts() == 0)
                        //{
                            if (Time.time > nextFire)
                            {
                                nextFire = Time.time + fireRate;
                                //gameController.incNumBolts();
                                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                                //timer.setPauseCount(true);
                                //Rotator.SetActive(false);
                                //PowerSlider.SetActive(false);
                                //gameObject.GetComponent<Timer>().enabled = false;
                                shoot.Play();
                                
                            }
                        //}
                    }
                }

            }

            if (Input.GetKey("up"))
            {
                //print ("up arrow key is held down");
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                //rotationText.text = transform.rotation.ToString();
            }

            if (Input.GetKey("down"))
            {
                //print ("down arrow key is held down");
                transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
                //rotationText.text = transform.rotation.ToString();
            }

            if (Input.GetKey("w"))
            {
                //print ("up arrow key is held down");
                transform.Translate(Vector3.up * vertSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("s"))
            {
                //print ("down arrow key is held down");
                transform.Translate(-Vector3.up * vertSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetButton("Jump") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                //Debug.Log(shotSpawn.position);
                //Debug.Log(shotSpawn.rotation.ToString());
                //spawnText.text = shotSpawn.position.ToString();
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                shoot.Play();
            }

        }

    }
}
