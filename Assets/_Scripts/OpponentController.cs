using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentController : MonoBehaviour {

    public Material[] spaceCraftMaterials;
    public Color32[] colors;


    private Vector3 _startPos;
    private Vector3 _destinationPos;
    private Quaternion _startRot;
    private Quaternion _destinationRot;

    private float _lastUpdateTime;
    private float _timePerUpdate = 0.16f;

    //private bool opponentDestroyed;

    public GameObject shotPrefab;
    public AudioSource shoot;

    private float initSpeed;

    //public Text spawnText;

    private float _startingPointX = 7.63f;

    private int health = 100;
    private Text player2Health;

    private GameController gameController;

    // Use this for initialization
    void Start () {
        //spawnText = GameObject.Find("spawn").GetComponent<Text>();
        player2Health = GameObject.Find("player2Health").GetComponent<Text>();
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _startPos = transform.position;
        _destinationPos = transform.position;
        //Debug.Log("Opponent spawned at " + _startPos.ToString());
        //spawnText.text = _startPos.ToString();
        _startRot = transform.rotation;
        //opponentDestroyed = false;
        _lastUpdateTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Opponent's possition : " + transform.position.ToString());
        // 1
        float pctDone = (Time.time - _lastUpdateTime) / _timePerUpdate;

        if (pctDone <= 1.0)
        {
            // 2
            transform.position = Vector3.Lerp(_startPos, _destinationPos, pctDone);
            transform.rotation = Quaternion.Slerp(_startRot, _destinationRot, pctDone);
        }
    }

    public void SetCarNumber(int carNum)
    {
        transform.FindChild("Player").GetComponent<Renderer>().material = spaceCraftMaterials[carNum - 1];
        //player2Health.color = colors[carNum - 1];
    }

    public void SetCarInformation(float rotZ, float posY)
    {
        //transform.position = new Vector3(_startingPointX, posY, 0);
        //transform.rotation = Quaternion.Euler(0, 0, 180f-rotZ);
        // We're going to do nothing with velocity.... for now

        //1
        _startPos = transform.position;
        //Debug.Log("Opponent is at " + _startPos.ToString());
        //spawnText.text = _startPos.ToString();
        
        _startRot = transform.rotation;
        //2
        _destinationPos = new Vector3(_startingPointX, posY, 0);
        _destinationRot = Quaternion.Euler(0, 0, 180f-rotZ);
        //3
        _lastUpdateTime = Time.time;
    }

    public void InstatitateShot(Vector3 position, Quaternion rotation) {
        //shotPrefab.GetComponent<Opponent_Mover>().setInitalSpeed(sliderSpeed);
        //Debug.Log("Slider value received is: " + sliderVal);
        
        Instantiate(shotPrefab, position, rotation);
        //shotPrefab.GetComponent<Rigidbody>().velocity = shotPrefab.transform.right * 10f * sliderSpeed * 0.02f;
        shoot.Play();
    }

    public float getInitSpeed() {
        return initSpeed;
    }

    public float lastUpdateTime { get { return _lastUpdateTime; } }

    public void DecreaseHealth()
    {
        
        health -= 34;
        Debug.Log("Opponent's health : " + health);
        player2Health.text = health.ToString();
        if (health < 0)
        {
            Debug.Log("You have won the game");
            //opponentDestroyed = true;
            gameController.setPlayer2Destroyed(true);
            gameController.GameOver(1);
            Destroy(gameObject);
        }
    }
}
