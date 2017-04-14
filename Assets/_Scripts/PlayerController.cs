using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float vertSpeed;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    private Touch touch;

    public Material[] spaceCraftMaterials;

    private int myTurn;

    //private GameObject gameManager;
    private GameController gameController;

	public GameObject menuPanel;

    public Slider speedSilder;

    public Text rotationText;  // public if you want to drag your text object in there manually
    //public Text spawnText;
    //int rotationZ;

    private bool playerDestroyed;

    public AudioSource shoot;

    private int health = 100;
    private Text player1Health;

    // Use this for initialization
    void Start() {
        rotationText = GameObject.Find("rotation").GetComponent<Text>();
        player1Health = GameObject.Find("player1Health").GetComponent<Text>();
        //spawnText = GameObject.Find("spawn").GetComponent<Text>();
        menuPanel = GameObject.Find("MenuPanel");
        menuPanel.SetActive(false);
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        speedSilder = GameObject.Find("Slider").GetComponent<Slider>();
        playerDestroyed = false;
    }

    // Update is called once per frame
    void Update() {

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
                    //gameController.getPlayerTurn() == myTurn &&

                    if (gameController.getPlayerTurn() == myTurn && touch.position.x < (Screen.width / 2) && touch.position.y < (Screen.height / 2))
					{
					    transform.Rotate(Vector3.forward * touch.deltaPosition.y * speed * Time.deltaTime);
					    //rotationText.text = transform.rotation.z.ToString();
					}

                    if (gameController.getPlayerTurn() == myTurn && touch.position.x < (Screen.width / 2) && touch.position.y > (Screen.height / 2))
                    {
                        
                        transform.Translate(Vector3.up * touch.deltaPosition.y  * Time.deltaTime, Space.World);
                        // initially, the temporary vector should equal the player's position
                        Vector3 clampedPosition = transform.position;
                        // Now we can manipulte it to clamp the y element
                        clampedPosition.y = Mathf.Clamp(transform.position.y, -5f, 5f);
                        // re-assigning the transform's position will clamp it
                        transform.position = clampedPosition;
                        //transform.Rotate(Vector3.forward * touch.deltaPosition.y * speed * Time.deltaTime);
                        //rotationText.text = transform.rotation.z.ToString();
                    }

                }
				else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
				{
					//do nothing
				}

				else
				{
					if (touch.position.x > (Screen.width / 2) && touch.position.y > (Screen.height / 2))
					{
						if (gameController.getPlayerTurn() == myTurn)
						{
						    if (Time.time > nextFire)
						    {
							    nextFire = Time.time + fireRate;
							    Debug.Log(shotSpawn.position);
							    Debug.Log(shotSpawn.rotation.ToString());
							    //spawnText.text = shotSpawn.position.ToString();
							    //rotationText.text = shotSpawn.rotation.eulerAngles.z.ToString() + "," + shotSpawn.rotation.eulerAngles.z.ToString() + "," + shotSpawn.rotation.eulerAngles.z.ToString();
							    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                                Debug.Log("SLider value sent is : " + speedSilder.value);
                                rotationText.text = speedSilder.value.ToString();
							    shoot.Play();
							    try
							    {
								    gameController.DoShotUpdate(shotSpawn.position, shotSpawn.eulerAngles.z, speedSilder.value);
							    }
							    catch (Exception e) {
								    Debug.Log("Exception " + e.ToString());
							    }
							    gameController.setPlayerTurn(1 - myTurn);
						    }
						}
					}
				}

			}

			if (Input.GetKey("up")) {
				//print ("up arrow key is held down");
				transform.Rotate(Vector3.forward * speed * Time.deltaTime);
				//rotationText.text = transform.rotation.ToString();
			}

			if (Input.GetKey("down")) {
				//print ("down arrow key is held down");
				transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
				//rotationText.text = transform.rotation.ToString();
			}

			if (Input.GetKey("w")) {
				//print ("up arrow key is held down");
				transform.Translate(Vector3.up * vertSpeed * Time.deltaTime, Space.World);
			}

			if (Input.GetKey("s")) {
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

    public void SetCarChoice(int carNum, bool isMultiplayer)
    {
        transform.FindChild("Player").GetComponent<Renderer>().material = spaceCraftMaterials[carNum - 1];
    }

    public void SetMyTurn(int i) {
        myTurn = i;
    }

    public int GetMyTurn()
    {
        return myTurn;
    }

    public bool GetPlayerDestroyed() {
        return playerDestroyed;
    }

    public void SetPlayerDestroyed(bool val)
    {
        playerDestroyed = val;
    }

    public void DecreaseHealth() {
        health -= 34;
        player1Health.text = health.ToString();
        if (health < 0) {
            playerDestroyed = true;
            gameController.GameOver(0);
            Destroy(gameObject);
        }
    }

}
