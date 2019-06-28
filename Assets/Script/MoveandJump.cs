using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveandJump : MonoBehaviour {
    private bool isJump;
    private bool Moving;
    private bool StopMoving;

    public float jumpForce = 50f;
    private float pSpeed = 150f;

    Rigidbody2D rb;
    
	// Use this for initialization
	void Start () {
        isJump = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void onjump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }

    public void onMove(bool _isRight)
    {
        if(_isRight)
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * pSpeed);

        if (!_isRight)
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * pSpeed);
    }
}
