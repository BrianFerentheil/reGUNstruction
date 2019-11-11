using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip : GunStats
{
    public enum gripModel { one, two, three, none }
    public gripModel currentGrip = gripModel.none;
    private int indexLength;
    private int curPos = 0;


    private void Start()
    {
        indexLength = System.Enum.GetValues(typeof(gripModel)).Length -1;
    }

    public gripModel NextPart()
    {
        ClearMods();

        curPos++;
        if(curPos >= indexLength)
        {
            curPos = 0;
        }

        currentGrip = (gripModel)curPos;
        return currentGrip;
    }

    public gripModel LastPart()
    {
        ClearMods();

        curPos--;
        if (curPos <= 0)
        {
            curPos = indexLength -1;
        }

        currentGrip = (gripModel)curPos;
        return currentGrip;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            //Debug.Log(indexLength + " " + curPos);
            Debug.Log((gripModel)curPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            //Debug.Log(indexLength + " " + curPos);
            Debug.Log((gripModel)curPos);
        }
    }

    public void RunStatMods(gripModel grip, GunStats stats)
    {
        switch (grip)
        {
            case gripModel.one:
                stats.damage += 0;
                stats.accuracy += 0;
                stats.recoil += 7;
                stats.durability += 3;
                stats.fireRate += 4;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.none;
                break;
            case gripModel.two:
                stats.damage += 2;
                stats.accuracy += 0;
                stats.recoil += 4;
                stats.durability += 3;
                stats.fireRate += 3;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.fire;
                break;
            case gripModel.three:
                stats.damage += 3;
                stats.accuracy += 0;
                stats.recoil += 3;
                stats.durability += 2;
                stats.fireRate += 4;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElement = element.explosive;
                break;
            //case gripModel.four:
            //    break;
            //case gripModel.five:
            //    break;
            case gripModel.none:
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
