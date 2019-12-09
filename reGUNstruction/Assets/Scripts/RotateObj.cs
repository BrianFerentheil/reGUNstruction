using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    public bool RotGun = false;
    public static bool atWorkBench = false;

    //public float speed = 1.0f;
    //// The target (cylinder) position.
    //private Transform target;


    //void Awake()
    //{
    //    // Position the cube at the origin.
    //    transform.position = new Vector3(16.38f, 1.34f, 15.1f);

    //    // Create and position the cylinder. Reduce the size.
    //    GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    //    Camera.main.transform.position = new Vector3(16.38f, 1.34f, 15.1f);

    //    // Grab cylinder values and place on the target.
    //    target = cylinder.transform;
    //    target.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
    //    target.transform.position = new Vector3(16.38f, 1.34f, 15.1f);

    //    // Position the camera.
    //    Camera.main.transform.position = new Vector3(3.52f, 1.489f, 7.6f);
    //    Camera.main.transform.localEulerAngles = new Vector3(15.0f, -20.0f, -0.5f);
    //}

    // Update is called once per frame
    void Update()
    {
        //// Move our position a step closer to the target.
        //float step = speed * Time.deltaTime; // calculate distance to move
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //// Check if the position of the cube and sphere are approximately equal.
        //if (Vector3.Distance(transform.position, target.position) < 0.001f)
        //{
        //    // Swap the position of the cylinder.
        //    target.position *= -1.0f;
        //}

        if (atWorkBench)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RotGun = true;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                RotGun = false;
            }
        }
        else if (RotGun)
        {
            RotGun = false;
        }

        if (RotGun)
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            if (Vector3.Dot(transform.up, Vector3.up) > -0)
            {

                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            }
            else
            {
                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            }

            transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        }

        mPrevPos = Input.mousePosition;


    }
}
