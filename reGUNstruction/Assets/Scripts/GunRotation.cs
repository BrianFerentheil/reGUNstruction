using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{

    public float RotateAmount = 1;
    public float RotateSpeed = 2;
    public GameObject GUN;
    public float RotateOnX;
    public float RotateOnY;
    public Quaternion DefaultRot;
    public Quaternion NewGunRot;

    float horizontalSpeed = 5.0f;
    float verticalSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //DefaultRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotateOnX += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * RotateAmount;
        RotateOnY += Input.GetAxis("Mouse Y") * Time.deltaTime * RotateAmount;
        //NewGunRot = new Quaternion(DefaultRot.x + RotateOnX, DefaultRot.y + RotateOnY, DefaultRot.z);
        NewGunRot = Quaternion.Euler(DefaultRot.x + RotateOnX, DefaultRot.y + RotateOnY, DefaultRot.z);
        GUN.transform.localRotation = Quaternion.Lerp(GUN.transform.localRotation, NewGunRot, RotateSpeed * Time.deltaTime);


        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);



    }
}
