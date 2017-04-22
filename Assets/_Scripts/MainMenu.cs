using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using System;

public class MainMenu : MonoBehaviour, MPLobbyListener
{
    private bool _showLobbyDialog;
    private string _lobbyMessage;
    //public GUISkin guiSkin;
	public GameObject soundPanel;
	public GameObject connectionPanel;
	public GameObject mainmenuPanel;
	public GameObject instructionPanel;
    public GameObject updatePanel;
    public GameObject logoutPanel;

    public GameObject shareButton;
    public GameObject helpButton;
    public GameObject rateButton;
    public GameObject logoutButton;



	public Text t;
    public Text logoutStatus;
	public GameObject logo;

	private GUIStyle currentStyle = null;

    //public MenuToggle menuToggle;

    private int firstTime = 1;
    public Slider mySlider;
    // Use this for initialization


    private void Awake()
    {

        Debug.Log("In awake");
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }

        soundPanel.SetActive(false);
        connectionPanel.SetActive(false);
        instructionPanel.SetActive(false);
        updatePanel.SetActive(false);
        logoutPanel.SetActive(false);

        string url = "http://anujbora.com/slingshot/version.php";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            //Debug.Log(www.text);
           // Debug.Log(Application.version);
            if (www.text != Application.version) {
                mainmenuPanel.SetActive(false);
                logo.SetActive(false);
                DisableButtons();
                updatePanel.SetActive(true);
            }   
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    void Start () {

        if (mainmenuPanel.active)
        {
            soundPanel.SetActive(false);
            connectionPanel.SetActive(false);
            instructionPanel.SetActive(false);
            updatePanel.SetActive(false);
            logoutPanel.SetActive(false);
        }

        /*string url = "http://anujbora.com/slingshot/version.php";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));*/


        AudioListener.volume = PlayerPrefs.GetFloat("SoundLevel", 1.0f);
        mySlider.value = AudioListener.volume;

        MultiplayerController.Instance.TrySilentSignIn();            
    }

    public void PlayGame()
    {
        firstTime = PlayerPrefs.GetInt("FirstPlay", 0);
        //Debug.Log("firstime : " + firstTime);
        if (firstTime == 0)
        {
            PlayerPrefs.SetInt("FirstPlay", 1);
            logo.SetActive(false);
            mainmenuPanel.SetActive(false);
            instructionPanel.SetActive(true);
            DisableButtons();
            //menuToggle.openInstructionMenu();

        }
        else
        {
            connectionPanel.SetActive(true);
            mainmenuPanel.SetActive(false);
            instructionPanel.SetActive(false);
            logo.SetActive(false);
            DisableButtons();

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                t.text = "You are not connected to internet... Please connect and try again!";
                //t.text = "not ok";
                return;
            }
            //Debug.Log("Pressed play");
            //_lobbyMessage = "Starting a multi-player game...";
            t.text = "Starting a multi-player game...";
            //_showLobbyDialog = true;
            MultiplayerController.Instance.lobbyListener = this;
            MultiplayerController.Instance.SignInAndStartMPGame();
        }

    }

    public void Offline()
    {
        //Debug.Log("Pressed offline");
        SceneManager.LoadScene(2);
    }

    public void openSoundMenu()
    {
        logo.SetActive(false);
        mainmenuPanel.SetActive(false);
        soundPanel.SetActive(true);
    }

    public void ShowInstructions()
    {
        logo.SetActive(false);
        mainmenuPanel.SetActive(false);
        instructionPanel.SetActive(true);
        DisableButtons();
    }

    public void Share() {
        FB.ShareLink(
            contentTitle: "Slingshot, an awesome mutiplayer game!",
            contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.FlyingSpaghetti.Slingshot"),
        contentDescription: "A multiplayer shooting strategy game set in space with planets and gravity",
        callback: OnShare);
        
    } 

    private void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share Link Error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
        {
            Debug.Log("Shared successfully");
        }
    }

    public void rateApp()
    {
        Application.OpenURL("market://details?id=com.FlyingSpaghetti.Slingshot");
    }

    public void UpdateApp()
    {
        Application.OpenURL("market://details?id=com.FlyingSpaghetti.Slingshot");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void Logout()
    {
        mainmenuPanel.SetActive(false);
        logo.SetActive(false);
        logoutPanel.SetActive(true);
        //Debug.Log("Pressed Logout");
        if (MultiplayerController.Instance.IsAuthenticated())
        {
            MultiplayerController.Instance.SignOut();
            logoutStatus.text = "You are successfully logged out!";
            
        }
        else {
            logoutStatus.text = "You are already logged out!";
        }
        Invoke("DisableLogoutPanel", 2.0f);
    }

    public void DisableLogoutPanel()
    {
       
        logoutPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
        logo.SetActive(true);
    }

    public void closeConnectionMenu()
    {
        // TODO:

        // leave room

        if (MultiplayerController.Instance.IsAuthenticated())
        {
            MultiplayerController.Instance.LeaveGame();
        }

        connectionPanel.SetActive(false);
        logo.SetActive(true);
        mainmenuPanel.SetActive(true);
        EnableButtons();      

    }

    public void closeInstructionMenu()
    {
        logo.SetActive(true);
        instructionPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
        EnableButtons();
    }

    public void closeSoundMenu()
    {
        logo.SetActive(true);
        soundPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
    }


    public void DisableButtons()
    {
        shareButton.SetActive(false);
        rateButton.SetActive(false);
        helpButton.SetActive(false);
        logoutButton.SetActive(false);
    }

    public void EnableButtons()
    {
        shareButton.SetActive(true);
        rateButton.SetActive(true);
        helpButton.SetActive(true);
        logoutButton.SetActive(true);
    }

    public void SetLobbyStatusMessage(string message)
    {
		t.text = message;
    }

    public void HideLobby()
    {
        _lobbyMessage = "";
        _showLobbyDialog = false;
    }


}
