using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Manager : MonoBehaviourPun {
    public bool PisJump;
    public bool PmoveRight;
    public bool PmoveLeft;
    public int speedMove;

    public Vector2 jumpForce = new Vector2(0,200);
    Rigidbody2D rb;

    public GameObject jumpB;
    public GameObject right;
    public GameObject left;

    public GameObject Targetp1;
    public GameObject Targetp2;

    public GameObject PlayerPref;
    public GameObject PlayerPref2;
    public GameObject[] SpawnPoints;
    //public GameObject arrow;
    //public Transform Pivot;
    public GameObject Bullet;

    public Transform[] SpawnObst;
    public Transform[] SpawnObst2;
    // Use this for initialization

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer1();
            SpawnTarget1();
        } else
        {
            SpawnPlayer2();
            SpawnTarget2();
        }
	}

    void SpawnTarget1()
    {
        PhotonNetwork.Instantiate(Targetp1.name, SpawnObst[0].position, Quaternion.identity);
        PhotonNetwork.Instantiate(Targetp1.name, SpawnObst[1].position, Quaternion.identity);
        PhotonNetwork.Instantiate(Targetp1.name, SpawnObst[2].position, Quaternion.identity);
    }

    void SpawnTarget2()
    {
        PhotonNetwork.Instantiate(Targetp2.name, SpawnObst2[0].position, Quaternion.identity);
        PhotonNetwork.Instantiate(Targetp2.name, SpawnObst2[1].position, Quaternion.identity);
        PhotonNetwork.Instantiate(Targetp2.name, SpawnObst2[2].position, Quaternion.identity);
    }

    void SpawnPlayer1()
    {
        PhotonNetwork.Instantiate(PlayerPref.name, SpawnPoints[0].transform.position, Quaternion.identity);
    }


    void SpawnPlayer2()
    {
        PhotonNetwork.Instantiate(PlayerPref2.name, SpawnPoints[1].transform.position, Quaternion.identity);
    }

    public void OnClickJump()
    {
        PisJump = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }
    /*void Fire()
    {
        GameObject chars = GameObject.Find("Chars(Clone)");
        UnityEngine.UI.Slider slider = FindObjectOfType<UnityEngine.UI.Slider>();
        GameObject arr = Instantiate(arrow, chars.GetComponentsInChildren<Transform>()[0].transform.position, Quaternion.Euler(0, 0, slider.value));
        arr.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
    }
    public void ShootOut()
    {
        GameObject arrow = PhotonNetwork.Instantiate(Bullet.name, Pivot.position, Pivot.rotation);
    }

    public void Jump()
    {
        PhotonView.Find(0).GetComponent<MoveandJump>().onjump();
    }

    public void OnClickMoveLeft()
    {
        PhotonView.Find(0).GetComponent<MoveandJump>().onMove(true);
    }

    public void OnClickMoveRight()
    {
        PhotonView.Find(0).GetComponent<MoveandJump>().onMove(false);
    }*/

    void FixedUpdate()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {

        }
        if (PmoveRight)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PlayerPref.transform.Translate(new Vector2(speedMove * Time.deltaTime, 0));
            }
            else
            {
                PlayerPref2.transform.Translate(new Vector2(speedMove * Time.deltaTime, 0));
            }
        }

        if (PmoveLeft)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PlayerPref.transform.Translate(new Vector2(-speedMove * Time.deltaTime, 0));
            }
            else
            {
                PlayerPref2.transform.Translate(new Vector2(-speedMove * Time.deltaTime, 0));
            }

        }
    }

    public void OnClickKiriDown()
    {
        PmoveLeft = true;
    }

    public void OnClickKiriUp()
    {
        PmoveLeft = false;
    }

    public void OnClickKanaDown()
    {
        PmoveRight = true;
    }

    public void OnClickKananUp()
    {
        PmoveRight = false;
    }

    public void OnJumpUp()
    {
        PisJump = false;
    }
}
