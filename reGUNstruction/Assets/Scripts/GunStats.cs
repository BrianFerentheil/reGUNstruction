using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    public float damage =5;
    public float accuracy =5;
    public float recoil =5;
    public float durability =5;
    public float fireRate =5;

    public string extraStatOne = " ";
    public string extraStatTwo = " ";

    public enum element { fire, ice, electric, plasma, acid, explosive, subatomic, none }
    public element myElementA = element.none;
    public element myElementB = element.none;
    public element myElementG = element.none;




    //protected enum gripModel { one, two, three, four, five, none }
    //protected enum ammoModel { one, two, three, four, five, none }
    //protected enum barrelModel { one, two, three, four, five, none }

    //gripModel thisGrip = gripModel.none;
    //ammoModel thisAmmo = ammoModel.none;
    //barrelModel thisBarrel = barrelModel.none;

    //protected void SetStats(GunModel.gunModel gModel, Grip.gripModel grip, Ammo.ammoModel ammo, Barrel.barrelModel barrel)
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

        extraStatOne = " ";
        extraStatTwo = " ";

        myElementA = element.none;
        myElementB = element.none;
        myElementG = element.none;

    }



}
