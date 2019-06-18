using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviour {

    public GameObject PlayerPref;
    public GameObject arrow;
    public Transform SpawnPoints;
    public Transform SpawnPoints2;
	// Use this for initialization
	void Start () {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer();
        }
        else
        {
            SpawnPlayer2();
        }
	}

    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(PlayerPref.name, SpawnPoints.position, Quaternion.identity);
    }

    void SpawnPlayer2()
    {
        PhotonNetwork.Instantiate(PlayerPref.name, SpawnPoints2.position, Quaternion.identity);
    }

    void Fire()
    {
        GameObject chars = GameObject.Find("Chars(Clone)");
        UnityEngine.UI.Slider slider = FindObjectOfType<UnityEngine.UI.Slider>();
        GameObject arr = Instantiate(arrow, chars.GetComponentsInChildren<Transform>()[0].transform.position, Quaternion.Euler(0, 0, slider.value));
        arr.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
}
