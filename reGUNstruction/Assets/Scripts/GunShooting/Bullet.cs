using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage  =1;
    public float speed = 100;
    public float destroyTime = 2.5f;

    public float explosiveForce;
    public float radius;
    public float upForce;

    public enum element { fire, ice, electric, plasma, acid, explosive, subatomic, none }
    element myEl = element.none;

    public GameObject bulletEffect;
    public GameObject parent;

    public GameObject bulletAfterEffect;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
        
        //transform.LookAt(CamRaycast.rayHit);
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    
    }

    void OnCollisionEnter(Collision other)
    {

        EnemyController enemy = other.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.die();
        }

        if (other.gameObject.tag == "Destroy")
        {
            Destroy(other.gameObject);
        }

        if(other.collider.GetComponent<Bullet>())
        {
            Physics.IgnoreCollision(other.collider.GetComponent<BoxCollider>(), this.GetComponent<BoxCollider>());
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider closeObjects in colliders)
        {
            Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
            Bullet bullet = closeObjects.GetComponent<Bullet>();
            if (rigidbody != null && bullet == null)
            {
                //rigidbody.AddExplosionForce(500f, transform.position, 50f);
                rigidbody.AddExplosionForce(explosiveForce, transform.position, radius, upForce, ForceMode.Impulse);

            }
        }

        //Rigidbody rB = other.transform.GetComponent<Rigidbody>();
        //if (rB != null)
        //{
        //    GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, other.transform.position, radius, upForce, ForceMode.Impulse);
        //}

        other.collider.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);

        var temp = Instantiate(bulletAfterEffect, transform.position, transform.rotation);
        temp.GetComponent<csDestroyEffect>().AEToggle(true);
        Destroy(gameObject);
    }

    public void SetBullet(GunStats gStats, GunModel.damageRange dRng, GunModel.bulletSpeed bSpd, GameObject gO, GameObject bEf, GameObject bAE )
    {
        switch (dRng)
        {
            case GunModel.damageRange.low:
                damage = 100f;
                explosiveForce = 5f;
                upForce = 5f;
                radius = 10;
                break;
            case GunModel.damageRange.med:
                damage = 200f;
                explosiveForce = 10f;
                upForce = 10f;
                radius = 20;

                break;
            case GunModel.damageRange.high:
                damage = 500f;
                explosiveForce = 20f;
                upForce = 20f;
                radius = 50;

                break;
            case GunModel.damageRange.none:
                Debug.Log("SetBullet Damage Error");
                break;
            default:
                break;
        }
        switch (bSpd)
        {
            case GunModel.bulletSpeed.low:
                speed = .5f;
                break;
            case GunModel.bulletSpeed.med:
                speed = 1f;
                break;
            case GunModel.bulletSpeed.fast:
                speed = 2f;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }

        myEl = (element)gStats.myElementA;
        parent = gO;
        bulletEffect = bEf;
        bulletAfterEffect = bAE;
        Instantiate(bulletEffect, transform);
        

    }
}
