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
    public GameObject planetPrefab;
    public GameObject planetsParent;
    //public GameObject shotPrefab;

    private GameObject myCar;
    private GameObject opponentCar;

    private bool _multiplayerReady;
    private string _myParticipantId;
    private Vector2 _startingPoint = new Vector2(-7.63f, 0f);
    private Dictionary<string, OpponentController> _opponentScripts;

    private int playerTurn = 0;

    public GameObject CircleSlider;
    //public RadialSlider 

    //public Text spawnText;  // public if you want to drag your text object in there manually
    //public Text rotationText;

    private bool player1Destroyed = false;
    private bool player2Destroyed = false;

    public float timeOutThreshold = 80.0f;
    private float _timeOutCheckInterval = 1.0f;
    private float _nextTimeoutCheck = 0.0f;

    private float initSpeed;

    private int numBolts = 0;

    public GameObject Rotator;
    public GameObject PowerSlider;

    private RandomPlanets randomize;
    private List<GameObject> planets;
    //public Text CountDown;

    Configuration[] t;
    Configuration obj;

    public Material[] planet_mats;
    //public GameObject planetPrefab;

    public Text player1Health;
    public Text player2Health;

    public Color32[] colors;

    private float _lastUpdateTime_Timer;

    void Start() {

        obj = new Configuration();
        t = obj.getList();

        _lastUpdateTime_Timer = Time.time;
        
        //playerController = myCar.GetComponent<PlayerController>();
        //randPlanets = new RandomPlanets();
        //randomize = new RandomPlanets();
        SetupMultiplayerGame();
    }

    void OnApplicationPause(bool val)
    {
        if(val == true)
        {
            player2Destroyed = true;
            GameOver(2);
        }

        if (val == false)
        {
            player2Destroyed = true;
            GameOver(2);
        }
    }

    void Update() {
        //if (playerTurn == playerController.GetMyTurn())
            
            DoMultiplayerUpdate();
        /*if (myCar.GetComponent<PlayerController>().GetPlayerDestroyed() || opponentCar.GetComponent<OpponentController>().GetOpponentDestroyed()) {
            //MultiplayerController.Instance.SendFinishMessage();
            Invoke("LeaveMPGame", 3.0f);
        }*/
    }

    private int InitializePlanets(int p, int x)
    {
        int i = Random.Range(0, t.Length);
        if (p == 1) i = x;
        Configuration c = t[i];
        if (c.scale1 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet1, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale1, t[i].scale1, t[i].scale1);
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[0];
        }

        if (c.scale2 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet2, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale2, t[i].scale2, t[i].scale2);
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[1];
        }

        if (c.scale3 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet3, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale3, t[i].scale3, t[i].scale3);
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[2];
        }

        if (c.scale4 != 0.0f)
        {
            GameObject planet = Instantiate(planetPrefab, t[i].planet4, Quaternion.identity);
            planet.transform.localScale = new Vector3(t[i].scale4, t[i].scale4, t[i].scale4);
            planet.transform.parent = planetsParent.transform;
            planet.transform.GetComponent<Renderer>().material = planet_mats[3];
        }
        return i;
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
                if (i == 0)
                {
                    int rand = InitializePlanets(0, 0);
                    //planets = randomize.CreatePlanets();
                    //DoPlanetUpdate(planets);
                    DoRandomUpdate(rand);
                }
                
                // 4
                carStartPoint = new Vector3(_startingPoint.x, _startingPoint.y, 0);
                player1Health.color = colors[i];
                myCar = (Instantiate(myCarPrefab, carStartPoint, Quaternion.identity) as GameObject);
                myCar.GetComponent<PlayerController>().SetCarChoice(i + 1, true);
                myCar.GetComponent<PlayerController>().SetMyTurn(i);
                myCar.GetComponent<Timer>().enabled = true;
                CircleSlider.GetComponent<RadialSlider>().enabled = true;
                /*if (i == 1)
                {
                    Rotator.SetActive(false);
                    PowerSlider.SetActive(false);
                }*/

                //myCar.transform.position = carStartPoint;
            }
            else
            {
                if (i == 1) {
                    foreach (Transform planet in planetsParent.transform)
                    {
                        planet.position = new Vector3(-planet.position.x, planet.position.y, planet.position.z);
                        planet.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
                    }
                }
                //Mirror Planets
                // 5
                player2Health.color = colors[i];
                carStartPoint = new Vector3(_startingPoint.x * -1, _startingPoint.y, 0);
                //Debug.Log("opponent is instantiated at " + carStartPoint.ToString());
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
        if (Time.time > _nextBroadcastTime && (!player1Destroyed && !player2Destroyed))
        {
            //rotationText.text = "sending " + playerTurn.ToString();
            if (playerTurn == myCar.GetComponent<PlayerController>().GetMyTurn())
            {
                MultiplayerController.Instance.SendMyUpdate(myCar.transform.rotation.eulerAngles.z, myCar.transform.position.y);
                _nextBroadcastTime = Time.time + .16f;
            }
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

    public void DoShotUpdate(Vector3 position, float rotationZ, float sliderVal)
    {
        MultiplayerController.Instance.SendMyUpdate_Shot(position.x, position.y, position.z, 0, 0, rotationZ, sliderVal);
    }

    public void DoTimerUpdate(int val) {
        MultiplayerController.Instance.SendMyUpdate_Timer(val);
    }

    public void DoRandomUpdate(int rand)
    {
        MultiplayerController.Instance.SendMyUpdate_Rand(rand);
    }

    public void DoPlanetUpdate(List<GameObject> planets)
    {
        Debug.Log("Sending planet coordiantes to opponent");
        Vector2[] positions = new Vector2[planets.Count];
        float[] scales = new float[planets.Count];
        for (int i = 0; i < planets.Count; i++) {
            positions[i].x = planets[i].transform.position.x;
            positions[i].y = planets[i].transform.position.y;
            scales[i] = planets[i].transform.localScale.x;
        }
        Debug.Log("Filed positions and scales arrray");
        MultiplayerController.Instance.SendMyUpdate_Planets(positions, scales);

    }

    public void UpdateReceived(string senderId, float rotZ, float posY)
    {
            OpponentController opponent = _opponentScripts[senderId];
            if (opponent != null)
            {
                opponent.SetCarInformation(rotZ, posY);
            }
    }


    public void UpdateReceived_Turn(string senderId, int turn)
    {
        //PowerSlider.SetActive(true);
        //Rotator.SetActive(true);
        _lastUpdateTime_Timer = Time.time;
        playerTurn = turn;
        //Timer.StartCounting();
        //rotationText.text = playerTurn.ToString();
    }

    public void UpdateReceived_Shot(string senderId, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float sliderVal)
    {
        Vector3 position = new Vector3(-posX, posY, posZ);
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 180f-rotZ);

        myCar.GetComponent<Timer>().setPauseCount(true);
        initSpeed = sliderVal;
        incNumBolts();
        opponentCar.GetComponent<OpponentController>().InstatitateShot(position, rotation);
    }

    public void UpdateReceived_Timer(string senderId, int val)
    {
        Debug.Log("Timer update recevied : change player and reset timer");
        playerTurn = val;
        myCar.GetComponent<Timer>().setTimeLeft(30);
    }

    public void UpdateReceived_Rand(string senderId, int rand)
    {
        InitializePlanets(1, rand);        
    }

    public void UpdateReceived_Planets(string senderId, Vector2[] positions, float[] scales)
    {
        for(int i=0; i<positions.Length; i++)
        {
            GameObject planet = Instantiate(planetPrefab, new Vector3(positions[i].x, positions[i].y, 0), Quaternion.identity);
            planet.transform.localScale = new Vector3(scales[i], scales[i], scales[i]);
            planet.transform.parent = planetsParent.transform;
        }
    }

    void CheckForTimeOuts()
    {
        /*foreach (string participantId in _opponentScripts.Keys)
        {
            
            if (_opponentScripts[participantId].lastUpdateTime < Time.time - timeOutThreshold)
            {
                // Haven't heard from them in a while!
                Debug.Log("Haven't heard from " + participantId + " in " + timeOutThreshold +
                              " seconds! They're outta here!");
                //PlayerLeftRoom(participantId);
                Invoke("LeaveMPGame", 3.0f);
            }
        }*/
        if (_lastUpdateTime_Timer < Time.time - timeOutThreshold)
        {
            GameOver(2);
        }
    }



    public int getPlayerTurn() {
        return playerTurn;
    }

    public void setPlayerTurn(int turn) {
        playerTurn = turn;
        myCar.GetComponent<Timer>().setTimeLeft(30);
        //myCar.GetComponent<PlayerController>().setNumBoltsShot(0);
        DoTurnUpdate();
    }

    public float getInitSpeed() {
        return initSpeed;
    }

    public void LeaveMPGame()
    {
        MultiplayerController.Instance.LeaveGame();
    }

    public void LeftRoomConfirmed()
    {
        Debug.Log("Left room confirmed, load main menu scnene now");
        MultiplayerController.Instance.updateListener = null;
        SceneManager.LoadScene(0);
    }

    public void GameOver(int player) {
        Debug.Log("Load main menu scene after 3 secs");
        Invoke("LeaveMPGame", 3.0f);
    }

    public void setPlayer1Destroyed(bool val) {
        player1Destroyed = val;
        GameOver(1);
    }

    public void setPlayer2Destroyed(bool val)
    {
        player2Destroyed = val;
        GameOver(2);
    }

    public int getNumBolts() {
        return numBolts;
    }

    public void decNumBolts() {
        numBolts = 0;
        /*if (playerTurn == myCar.GetComponent<PlayerController>().GetMyTurn())
        {
            //PowerSlider.SetActive(false);
            //Rotator.SetActive(false);
            setPlayerTurn(1 - myCar.GetComponent<PlayerController>().GetMyTurn());
        }*/
        //spawnText.text = numBolts.ToString();
    }

    public void incNumBolts()
    {
        numBolts = 1;
        //spawnText.text = numBolts.ToString();
    }

    public void ResetTimer() {
        //Rotator.SetActive(true);
        //PowerSlider.SetActive(true);
        myCar.GetComponent<Timer>().ResetCount();
    }


}
