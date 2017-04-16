using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeLeft = 30;
    public Text countDown;
    private GameController gameController;
    private PlayerController playerController;

    private bool pauseCount = false;

    //private int skip1 = 0;
    //private int skip2 = 0;

    // Use this for initialization
    /*void Start() {
        gameController = gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        countDown = GameObject.Find("CountDown").GetComponent<Text>();
        StartCounting();
    }*/

    void Start() {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        playerController = gameObject.GetComponent<PlayerController>();
        countDown = GameObject.Find("CountDown").GetComponent<Text>();
        StartCounting();
    }

    public void StartCounting() {
        timeLeft = 30;
        InvokeRepeating("Count", 0, 1);
    }

	// Update is called once per frame
	void Count () {
        if (!pauseCount)
        {
            Debug.Log(timeLeft);
            countDown.text = timeLeft.ToString();
            if (timeLeft == 0)
            {
                if (gameController.getPlayerTurn() == playerController.GetMyTurn() && gameController.getNumBolts() == 0)
                {
                    //gameController.setPlayerTurn(1 - myTurn);
                    Debug.Log("Timer run out: send update to change turn");
                    gameController.DoTimerUpdate(1 - playerController.GetMyTurn());
                    gameController.setPlayerTurn(1 - playerController.GetMyTurn());
                    timeLeft = 30;
                }
            }
            else timeLeft--;
        }
    }

    public int getTimeLeft()
    {
        return timeLeft;
    }

    public void setTimeLeft(int val)
    {
        timeLeft = val;
    }

    public void setPauseCount(bool val) {
        pauseCount = val;
    }

    public void ResetCount() {
        pauseCount = false;
        timeLeft = 30;
    }

}
