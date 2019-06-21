using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowmove : MonoBehaviour {
    [SerializeField]
    Rigidbody2D physic;
    public GameObject arrow;
    //Canvas cans;

    
	// Use this for initialization
	void Start () {
        physic = GetComponent<Rigidbody2D>();
        //cans = GetComponent<Canvas>();
        //cans.pixelRect.width.Equals(720f);
    }
	
	// Update is called once per frameam
	void Update () {
        transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
        Debug.Log("Move");
    }
     
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(collider.gameObject);
    }
}
