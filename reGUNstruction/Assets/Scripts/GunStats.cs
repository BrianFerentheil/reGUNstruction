using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStats : MonoBehaviour
{
    public float damage =5;
    public float accuracy =5;
    public float recoil =5;
    public float durability =5;
    public float fireRate =5;
    public int ammo = 8;

    public string extraStatOne = " ";
    public string extraStatTwo = " ";

    public enum element { fire, ice, electric, plasma, acid, explosive, subatomic, none }
    public element myElementA = element.none;
    public element myElementB = element.none;
    public element myElementG = element.none;

    public bool worldModel = false;

    public GameObject weaponUI;

    public GunModel myGun;


    //protected enum gripModel { one, two, three, four, five, none }
    //protected enum ammoModel { one, two, three, four, five, none }
    //protected enum barrelModel { one, two, three, four, five, none }

    //gripModel thisGrip = gripModel.none;
    //ammoModel thisAmmo = ammoModel.none;
    //barrelModel thisBarrel = barrelModel.none;

    //protected void SetStats(GunModel.gunModel gModel, Grip.gripModel grip, Ammo.ammoModel ammo, Barrel.barrelModel barrel)

    virtual protected void Start()
    {
        StartCoroutine(MakeAssignments());
    }

    private void Update()
    {

    }

    private IEnumerator MakeAssignments()
    {
        yield return new WaitForSeconds(.5f);

        weaponUI = FindObjectOfType<ButtonManager>().gunStatCanvas;
        if (myGun == null)
        {
            myGun = FindObjectOfType<GunModel>();
        }
    }

    public void SetStats(Grip.gripModel grip, Ammo.ammoModel ammo, Barrel.barrelModel barrel)
    {
        SetBaseParams();
        
    }

    public void SetBaseParams()
    {
        damage = 5;
        accuracy = 5;
        recoil = 5;
        durability = 5;
        fireRate = 5;
        ammo = 8;

        extraStatOne = " ";
        extraStatTwo = " ";

        myElementA = element.none;
        myElementB = element.none;
        myElementG = element.none;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (worldModel)
            {
                weaponUI.gameObject.SetActive(true);

                if (myGun == null)
                {
                    myGun = FindObjectOfType<GunModel>();
                }

                myGun.SetPiece(this);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (worldModel)
            {
                weaponUI.gameObject.SetActive(false);
            }
        }
    }

    virtual public void UpdateStatsUI()
    {

    }



}
