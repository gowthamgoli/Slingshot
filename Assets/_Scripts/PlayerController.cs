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
    public Text spawnText;
    private Timer timer;
    //int rotationZ;

    //private bool playerDestroyed;

    public AudioSource shoot;

    private int health = 100;
    private Text player1Health;

    //private int numBoltsShot = 0;

    // Use this for initialization
    void Start() {
        rotationText = GameObject.Find("rotation").GetComponent<Text>();
        player1Health = GameObject.Find("player1Health").GetComponent<Text>();
        spawnText = GameObject.Find("spawn").GetComponent<Text>();
        menuPanel = GameObject.Find("MenuPanel");
        timer = gameObject.GetComponent<Timer>();
        menuPanel.SetActive(false);
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        speedSilder = GameObject.Find("Slider").GetComponent<Slider>();
        //playerDestroyed = false;
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

                    if (gameController.getPlayerTurn() == myTurn && touch.position.x < (Screen.width / 2) && gameController.getNumBolts() == 0)
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
					if (touch.position.x > (Screen.width / 2) && touch.position.y > (Screen.height / 2))
					{
                        spawnText.text = gameController.getPlayerTurn().ToString();
                        if (gameController.getPlayerTurn() == myTurn && gameController.getNumBolts() == 0)
						{      
						    if (Time.time > nextFire)
						    {
							    nextFire = Time.time + fireRate;
                                gameController.incNumBolts();
                                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                                timer.setPauseCount(true);
                                //gameObject.GetComponent<Timer>().enabled = false;
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
            /*Debug.Log("Player Turn: " + gameController.getPlayerTurn());
            Debug.Log("Num of bolts: " + gameController.getNumBolts());
            Debug.Log("Time Left: " + timer.getTimeLeft());*/
            
            /*else if (gameController.getPlayerTurn() != myTurn && gameController.getNumBolts() == 0 && GetComponent<Timer>().getTimeLeft() == 0)
            {
                //gameController.setPlayerTurn(1 - myTurn);
                GetComponent<Timer>().setTimeLeft(30);

            }*/

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

    public void DecreaseHealth() {
        
        health -= 34;
        Debug.Log("Your health : " + health);
        player1Health.text = health.ToString();
        if (health < 0) {
            Debug.Log("Opponent has won the game");
            //playerDestroyed = true;
            gameController.setPlayer1Destroyed(true);
            //gameController.GameOver(0);
            Destroy(gameObject);
        }
    }

}
