using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShell : MonoBehaviour
{
    Rigidbody rigibody;
    public float force;
    
    void Start()
    {
        rigibody = this.GetComponent<Rigidbody>();
        rigibody.AddForce(new Vector3(1,1,0) * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
