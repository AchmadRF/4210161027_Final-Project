using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class arrowmove : MonoBehaviour {
    [SerializeField]
    Rigidbody2D physic;
    Manager mg;
    public GameObject arrow;
    public Transform trans;

    public float power = 15f;
    public float destroytime = 2f;

    public PhotonView pth;
    
	// Use this for initialization
	void Start () {
        physic = GetComponent<Rigidbody2D>();
    }

    IEnumerator DestroyBullets()
    {
        yield return new WaitForSeconds(destroytime);
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
    }

    // Update is called once per frameam
    void Update () {
        if (pth.IsMine)
        {
            if (arrow.tag == "ArrowP1")
            {
                transform.Translate(Vector2.right * Time.deltaTime * power);
            }
            else if(arrow.tag == "ArrowP2")
            {
                transform.Translate(Vector2.left * Time.deltaTime * power);
            }
        }
        else
        {
            if(arrow.tag == "ArrowP1")
            {
                transform.Translate(Vector2.left * Time.deltaTime * power);
            }
            else if(arrow.tag == "ArrowP2")
            {
                transform.Translate(Vector2.right * Time.deltaTime * power);
            }
        }
        //transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
    }

    /*public void ShootArrow()
    {
        if (mg.PlayerPref)
        {
            physic.AddForce(new Vector2(trans.position.x, 0), ForceMode2D.Force);
        }
        else if (mg.PlayerPref2)
        {
            physic.AddForce(new Vector2(-trans.position.x, 0), ForceMode2D.Force);
        }
    }*/

    void OnBecameInvisible()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(collider.gameObject);
    }

    [PunRPC]
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
