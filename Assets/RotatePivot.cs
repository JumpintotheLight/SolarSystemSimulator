using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePivot : MonoBehaviour {

    public float turnSpeed = 10.0f;
    public Vector3 axis = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(axis, Vector3.up, - turnSpeed * Time.deltaTime);
	}
}
