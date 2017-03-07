using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float turnSpeed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
    }
}
