using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public GameObject Pivot;
    public GameObject Bullet;
    //public Slider slider;
    
	// Use this for initialization
	void Start () {
        Pivot = this.gameObject;
        //Pivot = GetComponent<GameObject>();
        //slider = FindObjectOfType<Slider>();
	}
	
    void FixedUpdate()
    {
       
    }

    public void ShootOut()
    {
        GameObject arrow = Instantiate(Bullet, Pivot.transform.position, Pivot.transform.rotation);
        Debug.Log("shoot");
    }

}
