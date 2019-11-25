using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRaycast : MonoBehaviour
{

    public static Transform rayHit;
    Camera myCam;
    Ray myRay;
    RaycastHit myHit;

    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        //myRay = myCam.ScreenPointToRay(myCam.transform.forward);
        

        //if(Physics.Raycast(myRay, out myHit, 10000f))
        //{
        //    rayHit = myHit.transform;
        //}

            
    }
}
