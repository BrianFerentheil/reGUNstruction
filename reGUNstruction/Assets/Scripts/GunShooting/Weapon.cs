using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public Transform spawnTransform;
    public bool isFiring;
    public float timer;
    public bool raycast;
    public GameObject rayCastHit;

    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (raycast)
            {
                isFiring = true;
                RayCastFire();
            }
            else
            {
                isFiring = true;
                Fire();
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isFiring = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            raycast = !raycast;
        }
    }

    public void Fire()
    {
        if (!isFiring)
        {
            return;
        }
        else
        {
            if(timer >= fireRate)
            {
                timer = 0;
                Instantiate(bullet, spawnTransform);
            }
        }
    }

    public void RayCastFire()
    {
        if (!isFiring)
        {
            return;
        }
        else
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
            Instantiate(rayCastHit, hit.point, Quaternion.identity);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            

        }
    }
}
