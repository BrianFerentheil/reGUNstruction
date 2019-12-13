using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    public GameObject bulletS;
    public GameObject bulletL;
    public float fireRate;
    public Transform spawnTransform;
    public Transform bulletShellSpawn;
    public bool isFiring;
    public float timer;
    public bool raycast;
    public GameObject bulletShell;
    public GunBase gunBase;
    public GameObject beSFire;
    public GameObject beSVoid;
    public GameObject beSAcid;
    public GameObject beSIce;
    public GameObject beSLightning;
    public GameObject beSPlasma;
    public GameObject beMFire;
    public GameObject beMVoid;
    public GameObject beMAcid;
    public GameObject beMIce;
    public GameObject beMLightning;
    public GameObject beMPlasma;
    public GameObject beLFire;
    public GameObject beLVoid;
    public GameObject beLAcid;
    public GameObject beLIce;
    public GameObject beLLightning;
    public GameObject beLPlasma;
    public GameObject baeLFire;
    public GameObject baeLLightning;
    public GameObject baeLVoid;
    public GameObject baeLAcid;
    public GameObject baeLIce;
    public GameObject baeLPlasma;
    public GameObject baeMFire;
    public GameObject baeMLightning;
    public GameObject baeMVoid;
    public GameObject baeMAcid;
    public GameObject baeMIce;
    public GameObject baeMPlasma;
    public GameObject baeSFire;
    public GameObject baeSLightning;
    public GameObject baeSVoid;
    public GameObject baeSAcid;
    public GameObject baeSIce;
    public GameObject baeSPlasma;

    //New Particle Additions - 12/07/2019
    public GameObject beNova;
    public GameObject baeNova;
    public GameObject beHydro;
    public GameObject baeHydro;
    public GameObject beQuantum;
    public GameObject baeQuantum;
    public GameObject beMystic;
    public GameObject baeMystic;
    public GameObject beNuclear;
    public GameObject baeNuclear;

    public GameObject[] gunParticles;
    public GameObject bES;
    public GameObject bEM;
    public GameObject bEL;
    public GameObject bAES;
    public GameObject bAEM;
    public GameObject bAEL;

    //public GameObject target;
    //public Transform targetTransform;

    public Bullet tempBullet;
    public GunStats gStats;
    public GunStats tStats;

    public GunModel.damageRange dRng;
    public GunModel.bulletSpeed bSpd;

    public ParticlePack myParts;

    public int curAmmo = 0;
    public int maxAmmo = 0;
    public int clips;
    public bool reloading = false;
    public string clipText = " ";
    public string ammoText = " ";
    public TMP_Text clipUI;
    public TMP_Text ammoUI;

    void Awake()
    {
        LoadParticles();
        myParts = new ParticlePack();
        ButtonManager buttMan = FindObjectOfType<ButtonManager>();
        ammoUI = buttMan.ammoCanvas.transform.GetChild(1).GetComponent<TMP_Text>();
        clipUI = buttMan.ammoCanvas.transform.GetChild(2).GetComponent<TMP_Text>();
        clips = 3;
        

    }

    void LoadParticles()
    {
        beSFire = (GameObject)Resources.Load("Prefabs/BulletParticles/beSFire");
        beSVoid = (GameObject)Resources.Load("Prefabs/BulletParticles/beSVoid");
        beSAcid = (GameObject)Resources.Load("Prefabs/BulletParticles/beSAcid");
        beSIce = (GameObject)Resources.Load("Prefabs/BulletParticles/beSIce");
        beSLightning = (GameObject)Resources.Load("Prefabs/BulletParticles/beSLightning");
        beSPlasma = (GameObject)Resources.Load("Prefabs/BulletParticles/beSPlasma");
        beMFire = (GameObject)Resources.Load("Prefabs/BulletParticles/beMFire");
        beMVoid = (GameObject)Resources.Load("Prefabs/BulletParticles/beMVoid");
        beMAcid = (GameObject)Resources.Load("Prefabs/BulletParticles/beMAcid");
        beMIce = (GameObject)Resources.Load("Prefabs/BulletParticles/beMIce");
        beMLightning = (GameObject)Resources.Load("Prefabs/BulletParticles/beMLightning");
        beMPlasma = (GameObject)Resources.Load("Prefabs/BulletParticles/beMPlasma");
        beLFire = (GameObject)Resources.Load("Prefabs/BulletParticles/beLFire");
        beLVoid = (GameObject)Resources.Load("Prefabs/BulletParticles/beLVoid");
        beLAcid = (GameObject)Resources.Load("Prefabs/BulletParticles/beLAcid");
        beLIce = (GameObject)Resources.Load("Prefabs/BulletParticles/beLIce");
        beLLightning = (GameObject)Resources.Load("Prefabs/BulletParticles/beLLightning");
        beLPlasma = (GameObject)Resources.Load("Prefabs/BulletParticles/beLPlasma");
        baeLFire = (GameObject)Resources.Load("Prefabs/BulletParticles/baeLFire");
        baeLLightning = (GameObject)Resources.Load("Prefabs/BulletParticles/baeLLightning");
        baeLVoid = (GameObject)Resources.Load("Prefabs/BulletParticles/baeLVoid");
        baeLAcid = (GameObject)Resources.Load("Prefabs/BulletParticles/baeLAcid");
        baeLIce = (GameObject)Resources.Load("Prefabs/BulletParticles/baeLIce");
        baeLPlasma = (GameObject)Resources.Load("Prefabs/BulletParticles/baeLPlasma");
        baeMFire = (GameObject)Resources.Load("Prefabs/BulletParticles/baeMFire");
        baeMLightning = (GameObject)Resources.Load("Prefabs/BulletParticles/baeMLightning");
        baeMVoid = (GameObject)Resources.Load("Prefabs/BulletParticles/baeMVoid");
        baeMAcid = (GameObject)Resources.Load("Prefabs/BulletParticles/baeMAcid");
        baeMIce = (GameObject)Resources.Load("Prefabs/BulletParticles/baeMIce");
        baeMPlasma = (GameObject)Resources.Load("Prefabs/BulletParticles/baeMPlasma");
        baeSFire = (GameObject)Resources.Load("Prefabs/BulletParticles/baeSFire");
        baeSLightning = (GameObject)Resources.Load("Prefabs/BulletParticles/baeSLightning");
        baeSVoid = (GameObject)Resources.Load("Prefabs/BulletParticles/baeSVoid");
        baeSAcid = (GameObject)Resources.Load("Prefabs/BulletParticles/baeSAcid");
        baeSIce = (GameObject)Resources.Load("Prefabs/BulletParticles/baeSIce");
        baeSPlasma = (GameObject)Resources.Load("Prefabs/BulletParticles/baeSPlasma");

        bulletS = (GameObject)Resources.Load("Prefabs/BulletS");
        bulletL = (GameObject)Resources.Load("Prefabs/BulletL");
        bulletShell = (GameObject)Resources.Load("Prefabs/BulletShell");

        //Particle Name Need Updating When Folder Reference is Renames
        beNova = (GameObject)Resources.Load("Prefabs/BulletParticles/Buff2");
        baeNova = (GameObject)Resources.Load("Prefabs/BulletParticles/Buff2");
        beHydro = (GameObject)Resources.Load("Prefabs/BulletParticles/Buff3");
        baeHydro = (GameObject)Resources.Load("Prefabs/BulletParticles/Buff3");
        beQuantum = (GameObject)Resources.Load("Prefabs/BulletParticles/DarkBall");
        baeQuantum = (GameObject)Resources.Load("Prefabs/BulletParticles/DarkBall");
        beMystic = (GameObject)Resources.Load("Prefabs/BulletParticles/Explosion2");
        baeMystic = (GameObject)Resources.Load("Prefabs/BulletParticles/Explosion2");
        beNuclear = (GameObject)Resources.Load("Prefabs/BulletParticles/Sparking");
        baeNuclear = (GameObject)Resources.Load("Prefabs/BulletParticles/Sparking");

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
                //RayCastFire();
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

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    raycast = !raycast;
        //}

        clipUI.text = clipText;
        ammoUI.text = ammoText;
    }

    public void Fire()
    {
        if (!isFiring)
        {
            return;
        }
        else
        {
            if(timer >= fireRate && !reloading)
            {
                timer = 0;


                if(dRng == GunModel.damageRange.high)
                {
                    tempBullet = Instantiate(bulletL, spawnTransform.position, spawnTransform.rotation).GetComponent<Bullet>();
                    tempBullet.SetBullet(gStats, dRng, bSpd, spawnTransform.gameObject, myParts);
                    Instantiate(bulletShell, bulletShellSpawn.position, bulletShellSpawn.rotation);
                }
                else
                {
                    tempBullet = Instantiate(bulletS, spawnTransform.position, spawnTransform.rotation).GetComponent<Bullet>();
                    tempBullet.SetBullet(gStats, dRng, bSpd, spawnTransform.gameObject, myParts);
                    Instantiate(bulletShell, bulletShellSpawn.position, bulletShellSpawn.rotation);
                }

                curAmmo--;
                ammoText = $"Ammo: { curAmmo.ToString()}/ {maxAmmo.ToString()}";

                if (curAmmo <= 0)
                {
                    CallReload();
                }
           
            }
        }
    }

    public void CallReload()
    {
        if(clips > 0)
        {
            clips--;
            reloading = true;
            StartCoroutine(Reload());
            ammoText = "Reloading";
            clipText = $"Clips: { clips.ToString()}/ 3";
        }
        else
        {
            NoClips();
        }
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        reloading = false;
        curAmmo = maxAmmo;
        ammoText = $"Ammo: { curAmmo.ToString()}/ {maxAmmo.ToString()}";
    }

    public void NoClips()
    {
        ammoText = "No Ammo Remaining";
        clipText = "No Clips Remaining";
        reloading = true;
    }

    //public void RayCastFire()
    //{
    //    if (!isFiring)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        //RaycastHit hit;
    //        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
    //        //Instantiate(explosion, hit.point, Quaternion.identity);
    //        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //        if (timer >= fireRate)
    //        {
    //            timer = 0;
    //            Instantiate(explodeBullet, spawnTransform);
    //            //Instantiate(lighting, spawnTransform);

    //        }

    //    }
    //}

    public void GetGunStats(GunStats myStats, GunModel.bulletSpeed bS, GunModel.damageRange dR)
    {
        gStats = myStats;
        bSpd = bS;
        dRng = dR;
        SetFireRate();
        SetBulletEffect();
    }

    //public void GetTempStats(GunStats tempStats, GunModel.bulletSpeed bS, GunModel.damageRange dR)
    //{
    //    tStats = tempStats;
    //    bSpd = bS;
    //    dRng = dR;
    //    SetFireRate();
    //    SetBulletEffect();
    //}

    //public void SetFireRate()
    //{
    //    switch (bSpd)
    //    {
    //        case GunModel.bulletSpeed.low:
    //            fireRate = .5f;
    //            break;
    //        case GunModel.bulletSpeed.med:
    //            fireRate = .3f;
    //            break;
    //        case GunModel.bulletSpeed.fast:
    //            fireRate = .15f;
    //            break;
    //        case GunModel.bulletSpeed.none:
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void SetFireRate()
    {
        switch (bSpd)
        {
            case GunModel.bulletSpeed.vLow:
                fireRate = .75f;
                break;
            case GunModel.bulletSpeed.low:
                fireRate = .5f;
                break;
            case GunModel.bulletSpeed.med:
                fireRate = .3f;
                break;
            case GunModel.bulletSpeed.fast:
                fireRate = .15f;
                break;
            case GunModel.bulletSpeed.vFast:
                fireRate = .1f;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }
    }

    public void SetBulletEffect()
    {
        //switch (gStats.myElementA)
        //{
        //    case GunStats.element.fire:
        //        bES = beSFire;
        //        bEM = beMFire;
        //        bEL = beLFire;
        //        bAES = baeSFire;
        //        bAEM = baeMFire;
        //        bAEL = baeLFire;
        //        break;

        //    case GunStats.element.ice:
        //        bES = beSIce;
        //        bEM = beMIce;
        //        bEL = beLIce;
        //        bAES = baeSIce;
        //        bAEM = baeMIce;
        //        bAEL = baeLIce;
        //        break;
        //    case GunStats.element.electric:
        //        bES = beSLightning;
        //        bEM = beMLightning;
        //        bEL = beLLightning;
        //        bAES = baeSLightning;
        //        bAEM = baeMLightning;
        //        bAEL = baeLLightning;
        //        break;
        //    case GunStats.element.plasma:
        //        bES = beSPlasma;
        //        bEM = beMPlasma;
        //        bEL = beLPlasma;
        //        bAES = baeSPlasma;
        //        bAEM = baeMPlasma;
        //        bAEL = baeLPlasma;
        //        break;
        //    case GunStats.element.acid:
        //        bES = beSAcid;
        //        bEM = beMAcid;
        //        bEL = beLAcid;
        //        bAES = baeSAcid;
        //        bAEM = baeMAcid;
        //        bAEL = baeLAcid;
        //        break;
        //    //case GunStats.element.explosive:
        //    //    bulletEffect = explosion;

        //    //    break;
        //    case GunStats.element.subatomic:
        //        bES = beSVoid;
        //        bEM = beMVoid;
        //        bEL = beLVoid;
        //        bAES = baeSVoid;
        //        bAEM = baeMVoid;
        //        bAEL = baeLVoid;
        //        break;
        //    case GunStats.element.none:
        //        break;
        //    default:
        //        break;
        //}

        switch (gStats.myElementA)
        {
            case GunStats.element.fire:
                bES = beSFire;
                bEM = beMFire;
                bEL = beLFire;
                bAES = baeSFire;
                bAEM = baeMFire;
                bAEL = baeLFire;
                break;

            case GunStats.element.ice:
                bES = beSIce;
                bEM = beMIce;
                bEL = beLIce;
                bAES = baeSIce;
                bAEM = baeMIce;
                bAEL = baeLIce;
                break;
            case GunStats.element.electric:
                bES = beSLightning;
                bEM = beMLightning;
                bEL = beLLightning;
                bAES = baeSLightning;
                bAEM = baeMLightning;
                bAEL = baeLLightning;
                break;
            case GunStats.element.plasma:
                bES = beSPlasma;
                bEM = beMPlasma;
                bEL = beLPlasma;
                bAES = baeSPlasma;
                bAEM = baeMPlasma;
                bAEL = baeLPlasma;
                break;
            case GunStats.element.acid:
                bES = beSAcid;
                bEM = beMAcid;
                bEL = beLAcid;
                bAES = baeSAcid;
                bAEM = baeMAcid;
                bAEL = baeLAcid;
                break;
            case GunStats.element.subatomic:
                bES = beSVoid;
                bEM = beMVoid;
                bEL = beLVoid;
                bAES = baeSVoid;
                bAEM = baeMVoid;
                bAEL = baeLVoid;
                break;
            case GunStats.element.nova:
                bES = beNova;
                bEM = beNova;
                bEL = beNova;
                bAES = baeNova;
                bAEM = baeNova;
                bAEL =  baeNova;
                break;
            case GunStats.element.hydro:
                bES = beHydro;
                bEM = beHydro;
                bEL = beHydro;
                bAES = baeHydro;
                bAEM = baeHydro;
                bAEL = baeHydro;
                break;
            case GunStats.element.quantum:
                bES = beQuantum;
                bEM = beQuantum;
                bEL = beQuantum;
                bAES = baeQuantum;
                bAEM = baeQuantum;
                bAEL = baeQuantum;
                break;
            case GunStats.element.mystic:
                bES = beMystic;
                bEM = beMystic;
                bEL = beMystic;
                bAES = baeMystic;
                bAEM = baeMystic;
                bAEL = baeMystic;
                break;
            case GunStats.element.nuclear:
                bES = beNuclear;
                bEM = beNuclear;
                bEL = beNuclear;
                bAES = baeNuclear;
                bAEM = baeNuclear;
                bAEL = baeNuclear;
                break;
            case GunStats.element.none:
                Debug.Log("No Element Found");
                break;
            default:
                Debug.Log("Default Case Occurred");
                break;
        }

        // Original
        //myParts.beSmall = bES;
        //myParts.beMedium = bEM;
        //myParts.beLarge = bEL;
        //myParts.baeSmall = bAES;
        //myParts.baeMedium = bAEM;
        //myParts.baeLarge = bAEL;

        //All small effects
        myParts.beSmall = bES;
        myParts.beMedium = bES;
        myParts.beLarge = bES;
        myParts.baeSmall = bES;
        myParts.baeMedium = bES;
        myParts.baeLarge = bES;

        maxAmmo = gStats.ammo;
        curAmmo = maxAmmo;

        clipText = $"Clips: { clips.ToString()}/ 3";
        ammoText = $"Ammo: { curAmmo.ToString()}/ {maxAmmo.ToString()}";
    }

    public void ResetClips()
    {
        clips = 3;
    }
}

public class ParticlePack
{
    public GameObject beSmall;
    public GameObject beMedium;
    public GameObject beLarge;
    public GameObject baeSmall;
    public GameObject baeMedium;
    public GameObject baeLarge;
    
}
