using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class RoomMaker : MonoBehaviourPunCallbacks {
    public InputField RoomName;
    public InputField JoinRoom;
    // Use this for initialization
    void Start () {
		
	}

    public void Make_Join()
    {
        PhotonNetwork.JoinRoom(JoinRoom.text, null);
    }

    public void Create_ToJoin()
    {
        PhotonNetwork.CreateRoom(RoomName.text, new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Failed To Join" + returnCode + "Message" + message);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
