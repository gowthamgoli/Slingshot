using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mover_Opponent : MonoBehaviour {

    private float initVelocity;
    private Rigidbody rb;
    public float speed;
    public GameObject opponentCar;
    public Text spawnText;
    //public GameObject gameManager;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        spawnText = GameObject.Find("spawn").GetComponent<Text>();
        initVelocity = GameObject.Find("GameManager").GetComponent<GameController>().getInitSpeed();
        spawnText.text = initVelocity.ToString();
        rb.velocity = transform.right * speed * initVelocity * 0.02f;
    }
	
}
