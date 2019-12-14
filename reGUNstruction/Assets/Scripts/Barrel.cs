using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : GunStats
{
    public enum barrelModel { one, two, three, four, five, six, seven,  none }
    public barrelModel currentBarrel = barrelModel.none;

    public int indexLength;
    public int curPos = 0;

    public SwitchModel swiMod;
    public bool modelsSET;

    protected override void Start()
    {
        base.Start();
        indexLength = System.Enum.GetValues(typeof(barrelModel)).Length -1;
        currentBarrel = (barrelModel)curPos;
        swiMod = GetComponent<SwitchModel>();
        if (swiMod.models.Length == 0)
            SetModels();
    }

    public void SetModels()
    {
        if (!modelsSET)
        {
            if (swiMod == null)
            {
                swiMod = GetComponent<SwitchModel>();
            }

            swiMod.models = new MeshFilter[3];
            swiMod.models[0] = FindObjectOfType<BMONE>().GetComponent<MeshFilter>();
            swiMod.models[1] = FindObjectOfType<BMTWO>().GetComponent<MeshFilter>();
            swiMod.models[2] = FindObjectOfType<BMTHREE>().GetComponent<MeshFilter>();
            modelsSET = true;
        }
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
        if (curPos < 0)
        {
            curPos = indexLength - 1;
        }

        currentBarrel = (barrelModel)curPos;
        return currentBarrel;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    LastPart();
        //    //Debug.Log(indexLength + " " + curPos);
        //    Debug.Log((barrelModel)curPos);
        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    NextPart();
        //    //Debug.Log(indexLength + " " + curPos);
        //    Debug.Log((barrelModel)curPos);
        //}
    }

    public void RunStatMods(barrelModel barrel, GunStats stats)
    {
        switch (barrel)
        {
            case barrelModel.one:
                stats.fireRate += 2;
                stats.stability = 0;
                stats.damage += 6;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.two:
                stats.fireRate += 6;
                stats.stability = 0;
                stats.damage += 2;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.three:
                stats.fireRate += 4;
                stats.stability = 0;
                stats.damage += 4;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.four:
                stats.fireRate += 8;
                stats.stability = 0;
                stats.damage += 6;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.five:
                stats.fireRate += 6;
                stats.stability = 0;
                stats.damage += 8;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.six:
                stats.fireRate += 7;
                stats.stability = 0;
                stats.damage += 7;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.seven:
                stats.fireRate += 12;
                stats.stability = 0;
                stats.damage += 12;
                stats.accuracy += 0;
                stats.durability += 0;
                break;
            case barrelModel.none:
                break;
            default:
                break;
        }
    }

    //public void RunStatMods(barrelModel barrel, GunStats stats)
    //{
    //    switch (barrel)
    //    {
    //        case barrelModel.one:
    //            stats.damage += 2;
    //            stats.accuracy += 4;
    //            stats.recoil += 2;
    //            stats.durability += 4;
    //            stats.fireRate += 0;
    //            stats.ammo += 0;
    //            stats.extraStatOne = " ";
    //            stats.extraStatTwo = " ";
    //            stats.myElementB = element.none;
    //            break;
    //        case barrelModel.two:
    //            stats.damage += -3;
    //            stats.accuracy += 5;
    //            stats.recoil += 0;
    //            stats.durability += 0;
    //            stats.fireRate += 2;
    //            stats.ammo += 3;

    //            stats.extraStatOne = " ";
    //            stats.extraStatTwo = " ";
    //            stats.myElementB = element.fire;
    //            break;
    //        case barrelModel.three:
    //            stats.damage += 5;
    //            stats.accuracy += 4;
    //            stats.recoil += 1;
    //            stats.durability += 0;
    //            stats.fireRate += -3;
    //            stats.ammo += 5;

    //            stats.extraStatOne = " ";
    //            stats.extraStatTwo = " ";
    //            stats.myElementB = element.explosive;
    //            break;
    //        //case barrelModel.four:
    //        //    break;
    //        //case barrelModel.five:
    //        //    break;
    //        case barrelModel.none:
    //            break;
    //        default:
    //            break;
    //    }
    //}

    private void ClearMods()
    {
        damage = 0;
        accuracy = 0;
        stability = 0;
        durability = 0;
        fireRate = 0;

        extraStatOne = " ";
        extraStatTwo = " ";

        myElementB = element.none;

    }

    public int GetCurPos()
    {
        return curPos;
    }

}

