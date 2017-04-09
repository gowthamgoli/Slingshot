using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour, MPUpdateListener {

    private float _nextBroadcastTime = 0;

    public GameObject myCarPrefab;
    public GameObject opponentPrefab;
    public GameObject shotPrefab;

    private GameObject myCar;
    private GameObject opponentCar;

    private bool _multiplayerReady;
    private string _myParticipantId;
    private Vector2 _startingPoint = new Vector2(-7.63f, 0f);
    private Dictionary<string, OpponentController> _opponentScripts;

    private int playerTurn = 0;

    public Text spawnText;  // public if you want to drag your text object in there manually
    public Text rotationText;

    public float timeOutThreshold = 30.0f;
    private float _timeOutCheckInterval = 1.0f;
    private float _nextTimeoutCheck = 0.0f;

    //public PlayerController playerController;

    void Start() {
        //playerController = myCar.GetComponent<PlayerController>();
        SetupMultiplayerGame();
    }

    void Update() {
        //if (playerTurn == playerController.GetMyTurn())
            DoMultiplayerUpdate();
        if (myCar.GetComponent<PlayerController>().GetPlayerDestroyed() || opponentCar.GetComponent<OpponentController>().GetOpponentDestroyed()) {
            //MultiplayerController.Instance.SendFinishMessage();

            Invoke("LeaveMPGame", 3.0f);
        }
    }

    void SetupMultiplayerGame()
    {
        MultiplayerController.Instance.updateListener = this;

        // TODO: Fill this out!
        // 1
        _myParticipantId = MultiplayerController.Instance.GetMyParticipantId();
        // 2
        List<Participant> allPlayers = MultiplayerController.Instance.GetAllPlayers();
        _opponentScripts = new Dictionary<string, OpponentController>(allPlayers.Count - 1);
        for (int i = 0; i < allPlayers.Count; i++)
        {
            string nextParticipantId = allPlayers[i].ParticipantId;
            Debug.Log("Setting up car for " + nextParticipantId);
            // 3
            Vector3 carStartPoint = Vector3.zero;
            
            if (nextParticipantId == _myParticipantId)
            {
                
                // 4
                carStartPoint = new Vector3(_startingPoint.x, _startingPoint.y, 0);
                myCar = (Instantiate(myCarPrefab, carStartPoint, Quaternion.identity) as GameObject);
                myCar.GetComponent<PlayerController>().SetCarChoice(i + 1, true);
                myCar.GetComponent<PlayerController>().SetMyTurn(i);
                //myCar.transform.position = carStartPoint;
            }
            else
            {
                if (i == 1) {
                    GameObject Planets = GameObject.Find("Planets");
                    foreach (Transform planet in Planets.transform)
                    {
                        planet.position = new Vector3(-planet.position.x, planet.position.y, planet.position.z);
                        planet.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
                    }
                }
                //Mirror Planets
                // 5
                carStartPoint = new Vector3(_startingPoint.x * -1, _startingPoint.y, 0);
                opponentCar = (Instantiate(opponentPrefab, carStartPoint, Quaternion.Euler(0, 0, -180f)) as GameObject);
                OpponentController opponentScript = opponentCar.GetComponent<OpponentController>();
                opponentScript.SetCarNumber(i + 1);
                // 6
                _opponentScripts[nextParticipantId] = opponentScript;
            }
        }
        // 7
        //_lapsRemaining = 3;
        //_timePlayed = 0;
        //guiObject.SetLaps(_lapsRemaining);
        //guiObject.SetTime(_timePlayed);
        //_multiplayerReady = true;
    }

    void DoMultiplayerUpdate()
    {
        if (Time.time > _nextBroadcastTime && playerTurn == myCar.GetComponent<PlayerController>().GetMyTurn())
        {
            rotationText.text = "sending " + playerTurn.ToString();
            MultiplayerController.Instance.SendMyUpdate(myCar.transform.rotation.eulerAngles.z);
            _nextBroadcastTime = Time.time + .16f;
        }

        if (Time.time > _nextTimeoutCheck)
        {
            CheckForTimeOuts();
            _nextTimeoutCheck = Time.time + _timeOutCheckInterval;
        }
    }

    void DoTurnUpdate() {
        MultiplayerController.Instance.SendMyUpdate_Turn(playerTurn);
    }

    public void DoShotUpdate(Vector3 position, float rotationZ)
    {
        MultiplayerController.Instance.SendMyUpdate_Shot(position.x, position.y, position.z, 0, 0, rotationZ);
    }

    public void UpdateReceived(string senderId, float rotZ)
    {
            OpponentController opponent = _opponentScripts[senderId];
            if (opponent != null)
            {
                opponent.SetCarInformation(rotZ);
            }
    }

    public void UpdateReceived_Turn(string senderId, int turn)
    {
        playerTurn = turn;
    }

    public void UpdateReceived_Shot(string senderId, float posX, float posY, float posZ, float rotX, float rotY, float rotZ)
    {
        Vector3 position = new Vector3(-posX, posY, posZ);
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 180f-rotZ);
        spawnText.text = position.ToString();
        //rotationText.text = rotation.eulerAngles.z.ToString() + "," + rotation.eulerAngles.z.ToString() + "," + rotation.eulerAngles.z.ToString();
        Instantiate(shotPrefab, position, rotation);

        /*Transform spawnShot = opponentCar.transform.FindChild("ShotSpawn");
        Debug.Log("position: " + spawnShot.position.ToString());
        Debug.Log("rotation: " + spawnShot.rotation.ToString());
        Instantiate(shotPrefab, spawnShot.position, spawnShot.rotation);*/
    }

    void CheckForTimeOuts()
    {
        foreach (string participantId in _opponentScripts.Keys)
        {
            
            if (_opponentScripts[participantId].lastUpdateTime < Time.time - timeOutThreshold)
            {
                // Haven't heard from them in a while!
                Debug.Log("Haven't heard from " + participantId + " in " + timeOutThreshold +
                              " seconds! They're outta here!");
                //PlayerLeftRoom(participantId);
                Invoke("LeaveMPGame", 3.0f);
            }
        }
    }

    public int getPlayerTurn() {
        return playerTurn;
    }

    public void setPlayerTurn(int turn) {
        playerTurn = turn;
        DoTurnUpdate();
    }

    public void LeaveMPGame()
    {
        MultiplayerController.Instance.LeaveGame();
    }

    public void LeftRoomConfirmed()
    {
        MultiplayerController.Instance.updateListener = null;
        SceneManager.LoadScene(0);
    }

}
