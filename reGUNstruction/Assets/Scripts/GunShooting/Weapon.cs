using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject explodeBullet;
    public float fireRate;
    public Transform spawnTransform;
    public bool isFiring;
    public float timer;
    public bool raycast;
    public GameObject fire;
    public GameObject explosion;
    public GameObject lighting;
    public GameObject purpleEnergy;
    public GameObject laser;
    public GameObject blueEnergy;
    public GameObject greenEnergy;
    public GameObject ice;
    public GameObject lightningCloud;
    public GameObject plasma;

    public GameObject bulletEffect;


    //public GameObject target;
    //public Transform targetTransform;

    public Bullet tempBullet;
    public GunStats gStats;

    public GunModel.damageRange dRng;
    public GunModel.bulletSpeed bSpd;

    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit hitL;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitL);
        GameObject target = GameObject.FindGameObjectWithTag("Target");
        if(target != null)
        {
            target.transform.position = hitL.point;
        }
        



        //Instantiate(target, hitL.point, Quaternion.identity);


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
                //Instantiate(bullet, spawnTransform);
                //Instantiate(lighting, spawnTransform);
                //Instantiate(lighting, Instantiate(bullet, spawnTransform).transform);
                //Instantiate(purpleEnergy, Instantiate(bullet, spawnTransform).transform);
                //tempBullet = Instantiate(bullet, spawnTransform).GetComponent<Bullet>();
                tempBullet = Instantiate(bullet, spawnTransform.position, spawnTransform.rotation).GetComponent<Bullet>();

                tempBullet.SetBullet(gStats, dRng, bSpd, spawnTransform.gameObject, bulletEffect);               
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
            //RaycastHit hit;
            //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
            //Instantiate(explosion, hit.point, Quaternion.identity);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (timer >= fireRate)
            {
                timer = 0;
                Instantiate(explodeBullet, spawnTransform);
                //Instantiate(lighting, spawnTransform);

            }

        }
    }

    public void GetGunStats(GunStats myStats, GunModel.bulletSpeed bS, GunModel.damageRange dR)
    {
        gStats = myStats;
        bSpd = bS;
        dRng = dR;
        SetFireRate();
        SetBulletEffect();
    }

    public void SetFireRate()
    {
        switch (bSpd)
        {
            case GunModel.bulletSpeed.low:
                fireRate = .75f;
                break;
            case GunModel.bulletSpeed.med:
                fireRate = .4f;
                break;
            case GunModel.bulletSpeed.fast:
                fireRate = .15f;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }
    }

    public void SetBulletEffect()
    {
        switch (gStats.myElementA)
        {
            case GunStats.element.fire:
                bulletEffect = fire;
                break;

            case GunStats.element.ice:
                bulletEffect = ice;

                break;
            case GunStats.element.electric:
                bulletEffect = lightningCloud;

                break;
            case GunStats.element.plasma:
                bulletEffect = plasma;

                break;
            case GunStats.element.acid:
                bulletEffect = greenEnergy;
                
                break;
            case GunStats.element.explosive:
                bulletEffect = explosion;

                break;
            case GunStats.element.subatomic:
                bulletEffect = purpleEnergy;

                break;
            case GunStats.element.none:
                break;
            default:
                break;
        }
    }
}
