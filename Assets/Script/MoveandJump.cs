using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveandJump : MonoBehaviour {
    [SerializeField] Rigidbody2D moveP;
    [SerializeField] Rigidbody2D pivotP;
    [SerializeField] private float pSpeed = 150f;
    
	// Use this for initialization
	void Start () {
        moveP = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Move()
    {
        moveP.AddForce(new Vector2(pSpeed, 0));
    }
}
