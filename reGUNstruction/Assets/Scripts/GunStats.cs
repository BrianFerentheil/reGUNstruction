using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStats : MonoBehaviour
{
    public float damage =0;
    public float accuracy =0;
    public float durability =0;
    public float fireRate =0;
    public int ammo = 0;
    public int stability = 0;

    public string extraStatOne = " ";
    public string extraStatTwo = " ";

    public enum element { fire, ice, electric, plasma, acid, subatomic, nova, hydro, quantum, mystic, nuclear, none }
    public element myElementA = element.none;
    public element myElementB = element.none;
    public element myElementG = element.none;

    public bool worldModel;

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
        damage = 0;
        accuracy = 0;
        durability = 0;
        fireRate = 0;
        ammo = 0;
        stability = 0;

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
