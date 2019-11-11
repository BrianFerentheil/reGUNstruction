using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : GunStats
{
    public enum barrelModel { one, two, three,  none }
    public barrelModel currentBarrel = barrelModel.none;

    private int indexLength;
    private int curPos = 0;


    private void Start()
    {
        indexLength = System.Enum.GetValues(typeof(barrelModel)).Length -1;
    }

    public barrelModel NextPart()
    {
        ClearMods();

        curPos++;
        if (curPos >= indexLength)
        {
            curPos = 0;
        }

        currentBarrel = (barrelModel)curPos;
        return currentBarrel;
    }

    public barrelModel LastPart()
    {
        ClearMods();

        curPos--;
        if (curPos <= 0)
        {
            curPos = indexLength - 1;
        }

        currentBarrel = (barrelModel)curPos;
        return currentBarrel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            //Debug.Log(indexLength + " " + curPos);
            Debug.Log((barrelModel)curPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            //Debug.Log(indexLength + " " + curPos);
            Debug.Log((barrelModel)curPos);
        }
    }

    public void RunStatMods(barrelModel barrel, GunStats stats)
    {
        switch (barrel)
        {
            case barrelModel.one:
                stats.damage += 2;
                stats.accuracy += 4;
                stats.recoil += 2;
                stats.durability += 4;
                stats.fireRate += 0;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.none;
                break;
            case barrelModel.two:
                stats.damage += 3;
                stats.accuracy += 5;
                stats.recoil += 0;
                stats.durability += 0;
                stats.fireRate += 2;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.fire;
                break;
            case barrelModel.three:
                stats.damage += 5;
                stats.accuracy += 4;
                stats.recoil += 1;
                stats.durability += 0;
                stats.fireRate += 1;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.explosive;
                break;
            //case barrelModel.four:
            //    break;
            //case barrelModel.five:
            //    break;
            case barrelModel.none:
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

