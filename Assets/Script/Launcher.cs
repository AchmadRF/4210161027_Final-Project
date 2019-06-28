using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks {

	// Use this for initialization
	void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("connected to server");
    }
	
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        //Terserah;
    }
    /*public override void OnJoinedLobby()
    {
        //Terserah
    }*/
    // Update is called once per frame
    void Update()
    {

    }
    
}
