public interface MPLobbyListener
{
    void SetLobbyStatusMessage(string message);
    void HideLobby();
}

public interface MPUpdateListener
{
    void UpdateReceived(string participantId, float rotZ);
    void UpdateReceived_Turn(string participantId, int turn);
    void UpdateReceived_Shot(string senderId, float posX, float posY, float posZ, float rotX, float rotY, float rotZ);
    void LeftRoomConfirmed();
}