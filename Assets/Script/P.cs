using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

public class P : MonoBehaviourPun,IPunObservable {
    public float speed;
    public float jumpForce = 20f;
    public float moveSp = 20f;
    float waktu;
    public float timeSpan = 100;
    float directX;
    public Rigidbody2D rb;
    bool kanan, kiri;
    private Vector3 NiceMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waktu = timeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            ProccessInputs();
        }
        else
        {
            movefluent();
        }
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }*/
    }

    public void GerakBebas()
    {

    }

    public void GerakLain()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(directX * moveSp, rb.velocity.y);
    }

    public void bolKiri()
    {
        kiri = true;
    }
    public void bolKiriFalse()
    {
        kiri = false;
    }

    public void bolKanan()
    {
        kanan = true;
    }
    public void bolKananFalse()
    {
        kanan = false;
    }

    private void movefluent()
    {
        transform.position = Vector3.Lerp(transform.position, NiceMove, Time.deltaTime * 10);
    }

    private void ProccessInputs()
    {
        directX = CrossPlatformInputManager.GetAxis("Horizontal");

    
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            PlayerJump();
        }
    }

    public void PlayerJump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            NiceMove = (Vector3)stream.ReceiveNext();
        }

    }

}
