using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBullet : MonoBehaviour
{

    public float speed;
    public float destroyTime;
    public GameObject explotion;
    public float explotionForce;
    public float radius;
    public float upForce;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    //void OnCollisionEnter(Collider other)
    //{
    //    
    //    
    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Instantiate(explotion, other.transform);
            this.GetComponent<Rigidbody>().AddExplosionForce(explotionForce, other.transform.position, radius, upForce, ForceMode.Impulse);
            Destroy(other.gameObject);
        }
        else
        {
            
            Instantiate(explotion, other.transform);
            this.GetComponent<Rigidbody>().AddExplosionForce(explotionForce, other.transform.position, radius, upForce, ForceMode.Impulse);
        }
        other.collider.gameObject.SendMessage("Damage", 1f, SendMessageOptions.DontRequireReceiver);
    }
}
