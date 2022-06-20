using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject joinRoomPanel;
    [SerializeField] TextMeshProUGUI feedbackText;

    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] TMP_InputField roomNameField;

    [SerializeField] TextMeshProUGUI connectionSatus;

    [SerializeField] GameObject buttonLoadArena;
    [SerializeField] GameObject buttonJoinRoom;


    string playerName = "";
    string roomName = "";
    string gameVersion = "1";

    public int count = 0;

    public List<string> arrName;


    void Reset()
    {
        Debug.Log("Reconnect");
        ConnectToPhoton();
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("connect");

        joinRoomPanel.SetActive(false);

        ConnectToPhoton();
    }

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void ConnectToPhoton()
    {
        connectionSatus.text = "Connecting ....";
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LocalPlayer.NickName = playerNameField.text;
            Debug.Log("JoinRoom: " + roomNameField.text);
            RoomOptions roomOptions = new RoomOptions();
            TypedLobby typedLobby = new TypedLobby(roomNameField.text, LobbyType.Default);
            PhotonNetwork.JoinOrCreateRoom(roomNameField.text, roomOptions, typedLobby);
        }
    }

    public void LoadArena()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            PhotonNetwork.LoadLevel("GamePlay");
        }
        else
        {
            feedbackText.text = "Minimum 2 Players required to Load Arena!";
        }
    }

    public override void OnConnected()
    {
        base.OnConnected();
        connectionSatus.text = "Connected";
        joinRoomPanel.SetActive(true);
        buttonLoadArena.SetActive(false);
        Destroy(connectionSatus, 2);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //isConnecting = false;
        joinRoomPanel.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        arrName.Add(PhotonNetwork.LocalPlayer.NickName);
        if (PhotonNetwork.IsMasterClient)
        {
            buttonLoadArena.SetActive(true);
            buttonJoinRoom.SetActive(false);
            feedbackText.text = "You are Lobby Leader";
        }
        else
        {
            feedbackText.text = "Connected to Lobby";
        }

    }

    //private IEnumerator CheckPlayerCount()
    //{
    //    while (true)
    //    {
    //        //check playercount here
    //        if (PhotonNetwork.CurrentRoom.PlayerCount <= 1)
    //        {
    //            FindObjectOfType<GameManager>().WinGame();
    //        }
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    public override void OnLeftRoom()
    {
        //PhotonNetwork.LoadLevel(0);
        //if (PhotonNetwork.IsMasterClient)
        //{

        //}
        arrName.Remove(PhotonNetwork.LocalPlayer.NickName);
        Debug.Log(arrName.Count);
        if(arrName.Count <= 1)
        {
            FindObjectOfType<GameManager>().WinGame();
        }
    }
}

