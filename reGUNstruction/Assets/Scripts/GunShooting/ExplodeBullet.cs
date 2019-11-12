using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBullet : MonoBehaviour
{

    public float speed;
    public float destroyTime;
    public GameObject explotion;

    void Start()
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
        {
            
            Destroy(other.gameObject);
        }
        else
        {
            Instantiate(explotion, other.transform);
        }
    }
}
