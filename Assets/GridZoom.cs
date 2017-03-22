using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridZoom : MonoBehaviour {

	

   
        private int scaleLevel = 1;
        private float scaler = 0.001f;
        private Vector3 scaleVector;
        private GameObject scale1;
        private GameObject scale2;
        private GameObject scale3;
        // Use this for initialization
        void Start()
        {
            scaleVector = new Vector3(scaler, scaler, scaler);
            scale1 = Instantiate(Resources.Load("GridPlane", typeof(GameObject))) as GameObject;
            scale2 = Instantiate(Resources.Load("GridPlane", typeof(GameObject))) as GameObject;
            scale3 = Instantiate(Resources.Load("GridPlane", typeof(GameObject))) as GameObject;
            scale1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            scale2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            scale3.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
            scale1.GetComponent<Renderer>().sortingOrder = 1;
            scale2.GetComponent<Renderer>().sortingOrder = 2;
            scale3.GetComponent<Renderer>().sortingOrder = 3;



        }
   


    // Update is called once per frame
    void Update () {
		
	}
}
