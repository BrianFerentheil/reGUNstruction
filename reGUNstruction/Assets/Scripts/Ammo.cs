using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : GunStats
{
    public enum ammoModel { one, two, three,  none }
    public ammoModel currentAmmo = ammoModel.none;

    private int indexLength;
    private int curPos = 0;
    
    private void Start()
    {
        indexLength = System.Enum.GetValues(typeof(ammoModel)).Length -1;
    }

    public ammoModel NextPart()
    {
        ClearMods();

        curPos++;
        if (curPos >= indexLength)
        {
            curPos = 0;
        }

        currentAmmo = (ammoModel)curPos;
        return currentAmmo;
    }

    public ammoModel LastPart()
    {
        ClearMods();
        curPos--;
        if (curPos < 0)
        {
            curPos = indexLength - 1;
        }

        currentAmmo = (ammoModel)curPos;
        
        return currentAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            //Debug.Log(indexLength + " " + curPos);
            Debug.Log((ammoModel)curPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            //Debug.Log(indexLength + " " + curPos);
            Debug.Log((ammoModel)curPos);
        }
    }

    public void RunStatMods(ammoModel ammo, GunStats stats)
    {
        switch (ammo)
        {
            case ammoModel.one:
                stats.damage += 1;
                stats.accuracy += 0;
                stats.recoil += 1;
                stats.durability += 0;
                stats.fireRate += 8;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.none;
                break;
            case ammoModel.two:
                stats.damage += 5;
                stats.accuracy += 0;
                stats.recoil += -2;
                stats.durability += 0;
                stats.fireRate += 3;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.fire;
                break;
            case ammoModel.three:
                stats.damage += 8;
                stats.accuracy += 0;
                stats.recoil += 0;
                stats.durability += 0;
                stats.fireRate += 2;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.explosive;
                break;
            //case ammoModel.four:
            //    break;
            //case ammoModel.five:
            //    break;
            case ammoModel.none:
                break;
            default:
                break;
        }
    }

    private void ClearMods()
    {
        damage = 0;
        accuracy = 0;
        recoil = 0;
        durability = 0;
        fireRate = 0;

        extraStatOne = " ";
        extraStatTwo = " ";

        myElement = element.none;

    }

}