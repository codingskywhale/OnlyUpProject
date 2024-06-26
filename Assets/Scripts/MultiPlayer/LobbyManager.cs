using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    #region Private Serialzable Fields

    [SerializeField] private Text StatusText;
    //[SerializeField] private GameObject waitPanel;

    #endregion

    #region Private Fields

    string gameVersion = "1";
    private readonly int MAX_USERS = 10;
    private bool connect = false;

    #endregion

    #region MonoBehavior CallBacks

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Connect();
    }

    #endregion

    #region Public Methods

    public void Connect()
    {
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #endregion


    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster() 
    {
        Debug.Log("OnConnectedToMaster()");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnDisconnected() -> PhotonNetwork.CreateRoom");
        PhotonNetwork.CreateRoom(Random.Range(1, 1000).ToString(), new RoomOptions { MaxPlayers = MAX_USERS });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom()");

        int currentPlayers = PhotonNetwork.CurrentRoom.Players.Count;




    }

    #endregion

}
