using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ButtonHandler : MonoBehaviour {

    public GameObject arrowPref1;
    public GameObject arrowPref2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shuuto()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject P1 = GameObject.Find("FantasyArcher_02(Clone)");
            GameObject arrow = PhotonNetwork.Instantiate(arrowPref1.name, 
                new Vector3(P1.transform.position.x + 1.5f *Time.deltaTime, P1.transform.position.y, P1.transform.position.z), Quaternion.Euler(0,0,180));
            arrowPref1.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            Debug.Log("manah");
        }
        else
        {
            GameObject P2 = GameObject.Find("FantasyArcher_01(Clone)");
            GameObject arrow = PhotonNetwork.Instantiate(arrowPref2.name, 
                new Vector3(P2.transform.position.x + 1.5f * Time.deltaTime, P2.transform.position.y, P2.transform.position.z), Quaternion.Euler(0, 0, -180));
            arrowPref2.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
    }
}