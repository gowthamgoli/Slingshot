using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GUISkin guiSkin;
    private bool _showLobbyDialog;
    private string _lobbyMessage;

    void Start() {
        MultiplayerController.Instance.TrySilentSignIn();
    }

    void OnGUI() {
        if (_showLobbyDialog)
        {
            Debug.Log("Show lobby msg");
            GUI.skin = guiSkin;
            GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.4f, Screen.width * 0.5f, Screen.height * 0.5f), _lobbyMessage);
        }
    }

	public void PlayGame () {
        Debug.Log("Pressed play");
        _lobbyMessage = "Starting a multi-player game...";
        _showLobbyDialog = true;
        MultiplayerController.Instance.mainMenuScript = this;
        MultiplayerController.Instance.SignInAndStartMPGame();

        /*if (_showLobbyDialog)
        {
            Debug.Log("Show lobby msg");
            GUI.skin = guiSkin;
            GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.4f, Screen.width * 0.5f, Screen.height * 0.5f), _lobbyMessage);
        }*/
        //SceneManager.LoadScene(1);
    }

    public void Multiplayer()
    {
        Debug.Log("Pressed multi");
        SceneManager.LoadScene(1);
    }

    public void Logout()
    {
        Debug.Log("Pressed Logout");
        if (MultiplayerController.Instance.IsAuthenticated()){
            MultiplayerController.Instance.SignOut();
        }
    }

    public void SetLobbyStatusMessage(string message)
    {
        _lobbyMessage = message;
    }

    public void HideLobby()
    {
        _lobbyMessage = "";
        _showLobbyDialog = false;
    }

}
