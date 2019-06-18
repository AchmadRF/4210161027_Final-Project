using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public GameObject Pivot;
    public Slider slider;
    public float Trajectory = 10f;
	// Use this for initialization
	void Start () {
        //Pivot = GameObject.Find("Chars");
        slider = FindObjectOfType<Slider>();
	}
	
    void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(0, 0, slider.value);
        //transform.RotateAround(Pivot.transform.localPosition, Vector3.back, Time.deltaTime * Trajectory);
    }

}
