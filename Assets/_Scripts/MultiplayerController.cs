using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MultiplayerController : RealTimeMultiplayerListener
{
    private static MultiplayerController _instance = null;

    private uint minimumOpponents = 1;
    private uint maximumOpponents = 1;
    private uint gameVariation = 0;

    public MPLobbyListener lobbyListener;
    public MPUpdateListener updateListener;

    private byte _protocolVersion = 1;
    // Byte + Byte + 2 floats for position + 2 floats for velcocity + 1 float for rotZ
    private int _updateMessageLength = 10;
    private int _updateMessageLength_Turn = 6;
    private int _updateMessageLength_Shot = 30;
    private List<byte> _updateMessage;
    private List<byte> _updateMessage_Turn;
    private List<byte> _updateMessage_Shot;

    private MultiplayerController()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        _updateMessage = new List<byte>(_updateMessageLength);
        _updateMessage_Turn = new List<byte>(_updateMessageLength_Turn);
        _updateMessage_Shot = new List<byte>(_updateMessageLength_Shot);
    }

    public void TrySilentSignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate((bool success) => {
                if (success)
                {
                    Debug.Log("Silently signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
                }
                else
                {
                    Debug.Log("Oh... we're not signed in.");
                }
            }, true);
        }
        else
        {
            Debug.Log("We're already signed in");
        }
    }

    public void SignInAndStartMPGame()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.localUser.Authenticate((bool success) => {
                if (success)
                {
                    Debug.Log("We're signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
                    // We could start our game now
                    StartMatchMaking();
                }
                else
                {
                    Debug.Log("Oh... we're not signed in.");
                }
            });
        }
        else
        {
            Debug.Log("You're already signed in.");
            // We could also start our game now
            StartMatchMaking();
        }
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    public bool IsAuthenticated()
    {
        return PlayGamesPlatform.Instance.localUser.authenticated;
    }

    private void StartMatchMaking()
    {
        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(minimumOpponents, maximumOpponents, gameVariation, this);
    }

    private void ShowMPStatus(string message)
    {
        //Debug.Log(message);
        if (lobbyListener != null)
        {
            lobbyListener.SetLobbyStatusMessage(message);
        }
    }

    #region Interface Methods
    public void OnRoomSetupProgress(float percent)
    {
        ShowMPStatus("We are " + percent + "% done with setup");
    }

    public void OnRoomConnected(bool success)
    {
        if (success)
        {
            ShowMPStatus("We are connected to the room! I would probably start our game now.");
            lobbyListener.HideLobby();
            lobbyListener = null;
            SceneManager.LoadScene(1);
        }
        else
        {
            ShowMPStatus("Uh-oh. Encountered some error connecting to the room.");
        }
    }

    public void OnLeftRoom()
    {
        ShowMPStatus("We have left the room.");
        if (updateListener != null)
        {
            updateListener.LeftRoomConfirmed();
        }
    }

    public void OnParticipantLeft(Participant participant)
    {
        throw new NotImplementedException();
    }

    public void OnPeersConnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
            ShowMPStatus("Player " + participantID + " has joined.");
        }
    }

    public void OnPeersDisconnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
            ShowMPStatus("Player " + participantID + " has left.");
        }
    }

    public void LeaveGame()
    {
        PlayGamesPlatform.Instance.RealTime.LeaveRoom();
    }


    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
    {
        ShowMPStatus("We have received some gameplay messages from participant ID:" + senderId);
        // We'll be doing more with this later...
        byte messageVersion = (byte)data[0];
        // Let's figure out what type of message this is.
        char messageType = (char)data[1];
        if (messageType == 'U' && data.Length == _updateMessageLength)
        {
            float rotZ = System.BitConverter.ToSingle(data, 2);
            float posY = System.BitConverter.ToSingle(data, 6);
            //Debug.Log("Player " + senderId + " is at rotation " + rotZ);
            // We'd better tell our GameController about this.
            if (updateListener != null)
            {
                updateListener.UpdateReceived(senderId, rotZ, posY);
            }
        }

        else if (messageType == 'T' && data.Length == _updateMessageLength_Turn)
        {
            int turn = System.BitConverter.ToInt32(data, 2);
            //Debug.Log("Player " + senderId + " sets turn to " + turn);
            // We'd better tell our GameController about this.
            if (updateListener != null)
            {
                updateListener.UpdateReceived_Turn(senderId, turn);
            }
        }

        else if (messageType == 'S' && data.Length == _updateMessageLength_Shot)
        {
            float posX = System.BitConverter.ToSingle(data, 2);
            float posY = System.BitConverter.ToSingle(data, 6);
            float posZ = System.BitConverter.ToSingle(data, 10);
            float rotX = System.BitConverter.ToSingle(data, 14);
            float rotY = System.BitConverter.ToSingle(data, 18);
            float rotZ = System.BitConverter.ToSingle(data, 22);
            float sliderVal = System.BitConverter.ToSingle(data, 26);
            // Debug.Log("Player " + senderId + " sets turn to " + turn);
            // We'd better tell our GameController about this.
            if (updateListener != null)
            {
                updateListener.UpdateReceived_Shot(senderId, posX, posY, posZ, rotX, rotY, rotZ, sliderVal);
            }
        }
    }

    #endregion

    public static MultiplayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MultiplayerController();
            }
            return _instance;
        }
    }

    public List<Participant> GetAllPlayers()
    {
        return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
    }

    public string GetMyParticipantId()
    {
        return PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId;
    }

    public void SendMyUpdate(float rotZ, float posY)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'U');
        _updateMessage.AddRange(System.BitConverter.GetBytes(rotZ));
        _updateMessage.AddRange(System.BitConverter.GetBytes(posY));
        byte[] messageToSend = _updateMessage.ToArray();
        //Debug.Log("Sending my update message  " + messageToSend + " to all players in the room");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(false, messageToSend);
    }

    public void SendMyUpdate_Turn(int turn)
    {
        _updateMessage_Turn.Clear();
        _updateMessage_Turn.Add(_protocolVersion);
        _updateMessage_Turn.Add((byte)'T');
        _updateMessage_Turn.AddRange(System.BitConverter.GetBytes(turn));
        byte[] messageToSend = _updateMessage_Turn.ToArray();
        //Debug.Log("Sending my update message  " + messageToSend + " to all players in the room");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, messageToSend);
    }

    public void SendMyUpdate_Shot(float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float sliderVal)
    {
        _updateMessage_Shot.Clear();
        _updateMessage_Shot.Add(_protocolVersion);
        _updateMessage_Shot.Add((byte)'S');
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(posX));
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(posY));
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(posZ));
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(rotX));
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(rotY));
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(rotZ));
        _updateMessage_Shot.AddRange(System.BitConverter.GetBytes(sliderVal));
        byte[] messageToSend = _updateMessage_Shot.ToArray();
        //Debug.Log("Sending my update message  " + messageToSend + " to all players in the room");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, messageToSend);
    }

}
