using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip : GunStats
{
    public enum gripModel { pistol, subMG, assaultR, shotG, none }
    public gripModel currentGrip = gripModel.none;
    public int indexLength;
    public int curPos = 0;

    public SwitchModel swiMod;
    bool modelsSET;


    protected override void Start()
    {
        base.Start();
        indexLength = System.Enum.GetValues(typeof(gripModel)).Length -1;
        currentGrip = (gripModel)curPos;
        swiMod = GetComponent<SwitchModel>();
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
            swiMod.models[0] = FindObjectOfType<GMONE>().GetComponent<MeshFilter>();
            swiMod.models[1] = FindObjectOfType<GMTWO>().GetComponent<MeshFilter>();
            swiMod.models[2] = FindObjectOfType<GMTHREE>().GetComponent<MeshFilter>();
            modelsSET = true;
        }
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
        if (curPos < 0)
        {
            curPos = indexLength -1;
        }

        currentGrip = (gripModel)curPos;
        return currentGrip;
    }

    private void Update()
    {

    }


    public void RunStatMods(gripModel grip, GunStats stats)
    {
        switch (grip)
        {
            case gripModel.pistol:
                stats.fireRate += 4;
                stats.stability = 5;
                stats.damage += 4;
                stats.accuracy += 5;
                stats.durability += 5;
                stats.ammo += 7;
                break;
            case gripModel.subMG:
                stats.fireRate += 12;
                stats.stability = 5;
                stats.damage += 4;
                stats.accuracy += 5;
                stats.durability += 5;
                stats.ammo += 20;
                break;
            case gripModel.assaultR:
                stats.fireRate += 8;
                stats.stability = 5;
                stats.damage += 8;
                stats.accuracy += 5;
                stats.durability += 5;
                stats.ammo += 12;
                break;
            case gripModel.shotG:
                stats.fireRate += 4;
                stats.stability = 5;
                stats.damage += 12;
                stats.accuracy += 5;
                stats.durability += 5;
                stats.ammo += 5;
                break;
            case gripModel.none:
                break;
            default:
                break;
        }
    }


    //public void RunStatMods(gripModel grip, GunStats stats)
    //{
    //    switch (grip)
    //    {
    //        case gripModel.one:
    //            stats.damage += 4;
    //            stats.accuracy += 0;
    //            stats.recoil += 7;
    //            stats.durability += 3;
    //            stats.fireRate += 2;
    //            stats.ammo += -2;

    //            stats.extraStatOne = " ";
    //            stats.extraStatTwo = " ";
    //            stats.myElementG = element.none;
    //            break;
    //        case gripModel.two:
    //            stats.damage += 9;
    //            stats.accuracy += 0;
    //            stats.recoil += 4;
    //            stats.durability += 3;
    //            stats.ammo += 3;

    //            stats.fireRate += 3;
    //            stats.extraStatOne = " ";
    //            stats.extraStatTwo = " ";
    //            stats.myElementG = element.fire;
    //            break;
    //        case gripModel.three:
    //            stats.damage += -3;
    //            stats.accuracy += 0;
    //            stats.recoil += 7;
    //            stats.durability += 2;
    //            stats.fireRate += 8;
    //            stats.ammo += 0;

    //            stats.extraStatOne = " ";
    //            stats.extraStatTwo = " ";
    //            stats.myElementG = element.explosive;
    //            break;
    //        //case gripModel.four:
    //        //    break;
    //        //case gripModel.five:
    //        //    break;
    //        case gripModel.none:
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
        ammo = 0;
    }

    public int GetCurPos()
    {
        return curPos;
    }

}
