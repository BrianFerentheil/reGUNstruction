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

    private void Start()
    {
        Destroy(gameObject, destroyTime);
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

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider closeObjects in colliders)
        {
            Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(500f, transform.position, 50f);
            }
        }

        Rigidbody rB = other.transform.GetComponent<Rigidbody>();
        if (rB != null)
        {
            GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, other.transform.position, radius, upForce, ForceMode.Impulse);
        }

        other.collider.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    public void SetBullet(GunStats gStats, GunModel.damageRange dRng, GunModel.bulletSpeed bSpd, GameObject gO, GameObject bEf )
    {
        switch (dRng)
        {
            case GunModel.damageRange.low:
                damage = .25f;
                explosiveForce = 500f;
                upForce = 500f;
                radius = 100f;
                break;
            case GunModel.damageRange.med:
                damage = 2f;
                explosiveForce = 1000f;
                upForce = 1000f;
                radius = 250f;

                break;
            case GunModel.damageRange.high:
                damage = 100f;
                explosiveForce = 2000f;
                upForce = 2000f;
                radius = 400f;

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
                speed = 1f;
                break;
            case GunModel.bulletSpeed.med:
                speed = 2f;
                break;
            case GunModel.bulletSpeed.fast:
                speed = 3f;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }

        myEl = (element)gStats.myElementA;
        parent = gO;
        bulletEffect = bEf;
        Instantiate(bulletEffect, transform);
        

    }
}
