using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float destroyTime;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        { Destroy(other.gameObject); }
    }
}
