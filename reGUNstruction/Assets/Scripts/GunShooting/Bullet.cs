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

    public GameObject bulletDestroyEffect;
    public GameObject bulletAfterEffect;

    public GameObject bulletAudio;

    ScoreManager sm;

    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        Destroy(gameObject, destroyTime);
        bulletAudio = Resources.Load<GameObject>("Prefabs/BulletAudio");
        Instantiate(bulletAudio).GetComponent<BulletAudioFollow>().myBullet = gameObject;
        //transform.LookAt(CamRaycast.rayHit);
    }
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name.Contains("BulletShell"))
        {
            return;
        }
        EnemyController enemy = other.transform.GetComponentInParent<EnemyController>();
        if (enemy != null)
        {
            enemy.die();
            Destroy(gameObject);

        }


        //if (other.gameObject.tag == "Destroy")
        //{
        //    int objectScore;
        //    objectScore = other.collider.GetComponent<Score>().score;
        //    sm.currentScore = sm.currentScore + objectScore;
        //    Destroy(other.gameObject);
        //}

        if (other.collider.GetComponent<Bullet>())
        {
            Physics.IgnoreCollision(other.collider.GetComponent<BoxCollider>(), this.GetComponent<BoxCollider>());
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider closeObjects in colliders)
        {
            Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
            Bullet bullet = closeObjects.GetComponent<Bullet>();
            Score score = closeObjects.GetComponent<Score>();
            if (rigidbody != null && bullet == null)
            {
                //rigidbody.AddExplosionForce(500f, transform.position, 50f);
                rigidbody.AddExplosionForce(explosiveForce, transform.position, radius, upForce, ForceMode.Impulse);
                if (enemy != null)
                {
                    enemy.die();
                    Destroy(gameObject);

                }
            }
            if(score != null)
            {
                int objectScore;
                objectScore = score.CallScore();
                sm.ScoreCheck();
                sm.currentScore += objectScore;
                score.DoTheParticle(bulletDestroyEffect);
                score.StartCoroutine(score.DestroyMe());
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

    public void SetBullet(GunStats gStats, GunModel.damageRange dRng, GunModel.bulletSpeed bSpd, GameObject gO, ParticlePack pP )
    {
        //switch (dRng)
        //{
        //    case GunModel.damageRange.low:
        //        damage = 100f;
        //        explosiveForce = 5f;
        //        upForce = 4f;
        //        radius = 1;
        //        bulletEffect = pP.beSmall;
        //        bulletAfterEffect = pP.beSmall;
        //        bulletDestroyEffect = pP.baeMedium;
        //        break;
        //    case GunModel.damageRange.med:
        //        damage = 200f;
        //        explosiveForce = 10f;
        //        upForce = 7.5f;
        //        radius = 2;
        //        bulletEffect = pP.beMedium;
        //        bulletAfterEffect = pP.baeMedium;
        //        bulletDestroyEffect = pP.baeMedium;
        //        break;
        //    case GunModel.damageRange.high:
        //        damage = 500f;
        //        explosiveForce = 20f;
        //        upForce = 12.5f;
        //        radius = 3;
        //        bulletEffect = pP.beLarge;
        //        bulletAfterEffect = pP.baeLarge;
        //        bulletDestroyEffect = pP.baeMedium;
        //        break;
        //    case GunModel.damageRange.none:
        //        Debug.Log("SetBullet Damage Error");
        //        break;
        //    default:
        //        break;
        //}
        switch (dRng)
        {
            case GunModel.damageRange.vLow:
                damage = 50;
                explosiveForce = 2.5f;
                upForce = 1.25f;
                radius = .5f;
                bulletEffect = pP.beSmall;
                bulletAfterEffect = pP.beSmall;
                bulletDestroyEffect = pP.baeSmall;
                break;
            case GunModel.damageRange.low:
                damage = 100f;
                explosiveForce = 5f;
                upForce = 4f;
                radius = 1;
                bulletEffect = pP.beSmall;
                bulletAfterEffect = pP.beSmall;
                bulletDestroyEffect = pP.baeMedium;
                break;
            case GunModel.damageRange.med:
                damage = 200f;
                explosiveForce = 10f;
                upForce = 7.5f;
                radius = 2;
                bulletEffect = pP.beMedium;
                bulletAfterEffect = pP.baeMedium;
                bulletDestroyEffect = pP.baeMedium;
                break;
            case GunModel.damageRange.high:
                damage = 500f;
                explosiveForce = 20f;
                upForce = 12.5f;
                radius = 3;
                bulletEffect = pP.beMedium;
                bulletAfterEffect = pP.baeMedium;
                bulletDestroyEffect = pP.baeMedium;
                break;
            case GunModel.damageRange.vHigh:
                damage = 750f;
                explosiveForce = 30f;
                upForce = 20f;
                radius = 7.5f;
                bulletEffect = pP.beLarge;
                bulletAfterEffect = pP.beLarge;
                bulletDestroyEffect = pP.baeMedium;
                break;
            case GunModel.damageRange.none:
                break;
            default:
                break;
        }
        //switch (bSpd)
        //{
        //    case GunModel.bulletSpeed.low:
        //        speed = .5f;
        //        break;
        //    case GunModel.bulletSpeed.med:
        //        speed = 1f;
        //        break;
        //    case GunModel.bulletSpeed.fast:
        //        speed = 2f;
        //        break;
        //    case GunModel.bulletSpeed.none:
        //        break;
        //    default:
        //        break;
        //}
        switch (bSpd)
        {
            case GunModel.bulletSpeed.vLow:
                speed = 1;
                break;
            case GunModel.bulletSpeed.low:
                speed = 2;
                break;
            case GunModel.bulletSpeed.med:
                speed = 3;
                break;
            case GunModel.bulletSpeed.fast:
                speed = 4;
                break;
            case GunModel.bulletSpeed.vFast:
                speed = 5;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }

        myEl = (element)gStats.myElementA;
        parent = gO;
        Instantiate(bulletEffect, transform);
        

    }
}
