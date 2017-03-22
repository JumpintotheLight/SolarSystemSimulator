using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltScale : MonoBehaviour {

    public GameObject CameraRig;

    public SteamVR_TrackedObject left;
    public SteamVR_TrackedObject right;

    private float prevDist = 0.0f;


    public float scalespeed = 10.0f;


    private float startTime;


    float dist = 0f;

    float delta = 0f;

    private void Start()
    {
        startTime = Time.time;

    }
    // Update is called once per frame
    void Update ()
    {

        //SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost));


        //var lDev = SteamVR_Controller.Input((int)left.index);
        //var rDev = SteamVR_Controller.Input((int)right.index);

        var lDev = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost));

        var rDev = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost));

        float t = (Time.time - startTime) / 0.001f;

        if ( lDev.GetPress( SteamVR_Controller.ButtonMask.Grip) && rDev.GetPress(SteamVR_Controller.ButtonMask.Grip) )
        {
            // Check this!!!
            

            Vector3 vect = left.transform.position - right.transform.position;

            //dist = Mathf.Lerp(prevDist, dist, t);
            dist = (left.transform.position.x - right.transform.position.x) / CameraRig.transform.localScale.x;


            //dist = Mathf.Lerp(dist, prevDist, 0.001f);
            delta = dist - prevDist;

            Debug.Log("dist = " + dist );
            Debug.Log("prevDist = " + prevDist);

            Debug.Log("delta = " + delta );
            //Debug.Log("scale = " + CameraRig.transform.localScale);

            //if( (Mathf.Abs(dist) > 0.0001f) && (CameraRig.transform.localScale.x >0.0001) )
            //if ((Mathf.Abs(dist) > 0.0001f) && Mathf.Abs(dist) < 100000 )


            
            if (Mathf.Abs(delta) > 0.001f)
            { 
            if(delta>0 )
             {
                    //CameraRig.transform.localScale += (Vector3.one * Time.deltaTime * Mathf.Sign(delta) * scalespeed);
                    CameraRig.transform.localScale += Vector3.Lerp((Vector3.one * (prevDist) * scalespeed ), (Vector3.one * (dist) * scalespeed), 0.01f );
                //lerpScale(delta * scalespeed);

            }
            else 
            {
                CameraRig.transform.localScale -= (Vector3.one * (dist) * scalespeed);

            }
            }

            prevDist = dist;
        }

        prevDist = dist;

        

        // Use this to reset the scale to 1
        if (lDev.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && rDev.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector3 scale = CameraRig.transform.localScale;
            scale.Set(1, 1, 1);
            CameraRig.transform.localScale = scale;
        }

    }

    
    public IEnumerator lerpScale(float newScale)
    {

        var originalScale = transform.localScale;
        var targetScale = originalScale + new Vector3(newScale, newScale, newScale);
        var originalTime = Time.deltaTime;


        while (true)
        {


            transform.localScale = Vector3.Lerp(targetScale, originalScale, Time.deltaTime / originalTime);
            yield return null;

        }
    }
}
