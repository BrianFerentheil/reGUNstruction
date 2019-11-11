using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    protected float damage =5;
    protected float accuracy =5;
    protected float recoil =5;
    protected float durability =5;
    protected float fireRate =5;

    protected string extraStatOne = " ";
    protected string extraStatTwo = " ";

    protected enum element { fire, ice, electric, plasma, acid, explosive, subatomic, none }
    protected element myElement = element.none;

    protected enum gripModel { one, two, three, four, five, none }
    protected enum ammoModel { one, two, three, four, five, none }
    protected enum barrelModel { one, two, three, four, five, none }

    gripModel thisGrip = gripModel.none;
    ammoModel thisAmmo = ammoModel.none;
    barrelModel thisBarrel = barrelModel.none;

    protected void SetStats(GunModel.gunModel gModel, Grip.gripModel grip, Ammo.ammoModel ammo, Barrel.barrelModel barrel)
    {

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

        myElement = element.none;
    }


}
