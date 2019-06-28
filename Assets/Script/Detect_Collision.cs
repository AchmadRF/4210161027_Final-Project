using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Collision : MonoBehaviour {

    public GameObject Arrow;
    public GameObject[] playerTarget;

    public bool isHit;
    private float ForceBack = 10f;
    private int CountWin = 3;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggered2D(Collider2D col) 
    {
        if (isHit)
        {
           
        }
    }
}
