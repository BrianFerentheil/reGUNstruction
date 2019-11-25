using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : GunStats
{
    public enum ammoModel { one, two, three, four, five, six, none }
    public ammoModel currentAmmo = ammoModel.none;

    public int indexLength;
    public int curPos = 0;

    public SwitchModel swiMod;
    public bool modelSET;

    protected override void Start()
    {
        base.Start();
        indexLength = System.Enum.GetValues(typeof(ammoModel)).Length -1;
        currentAmmo = (ammoModel)curPos;
        swiMod = GetComponent<SwitchModel>();
        SetModels();
    }

    public void SetModels()
    {
        if (!modelSET)
        {
            if (swiMod == null)
            {
                swiMod = GetComponent<SwitchModel>();
            }

            swiMod.models = new MeshFilter[6];
            swiMod.models[0] = FindObjectOfType<AMONE>().GetComponent<MeshFilter>();
            swiMod.models[1] = FindObjectOfType<AMTWO>().GetComponent<MeshFilter>();
            swiMod.models[2] = FindObjectOfType<AMTHREE>().GetComponent<MeshFilter>();
            swiMod.models[3] = FindObjectOfType<AMFOUR>().GetComponent<MeshFilter>();
            swiMod.models[4] = FindObjectOfType<AMFIVE>().GetComponent<MeshFilter>();
            swiMod.models[5] = FindObjectOfType<AMSIX>().GetComponent<MeshFilter>();
            modelSET = true;
        }
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
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    LastPart();
        //    //Debug.Log(indexLength + " " + curPos);
        //    Debug.Log((ammoModel)curPos);
        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    NextPart();
        //    //Debug.Log(indexLength + " " + curPos);
        //    Debug.Log((ammoModel)curPos);
        //}
    }

    public void UpdateMyStats()
    {
        switch (currentAmmo)
        {
            case ammoModel.one:
                damage += 0;
                accuracy += 0;
                recoil += 7;
                durability += 3;
                fireRate += 4;
                extraStatOne = " ";
                extraStatTwo = " ";
                myElementA = element.plasma;
                break;
            case ammoModel.two:
                damage += 2;
                accuracy += 0;
                recoil += 4;
                durability += 3;
                fireRate += 3;
                extraStatOne = " ";
                extraStatTwo = " ";
                myElementA = element.electric;
                break;
            case ammoModel.three:
                damage += 3;
                accuracy += 0;
                recoil += 3;
                durability += 2;
                fireRate += 4;
                extraStatOne = " ";
                extraStatTwo = " ";
                myElementA = element.acid;
                break;
            //case gripModel.four:
            //    break;
            //case gripModel.five:
            //    break;
            case ammoModel.none:
                break;
            default:
                break;
        }
    }

    public void RunStatMods(ammoModel ammo, GunStats stats)
    {
        switch (ammo)
        {
            case ammoModel.one:
                stats.damage += 1;
                stats.accuracy += 0;
                stats.recoil += 5;
                stats.durability += 0;
                stats.fireRate += 8;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElementA = element.subatomic;
                break;
            case ammoModel.two:
                stats.damage += 5;
                stats.accuracy += 0;
                stats.recoil += 2;
                stats.durability += 0;
                stats.fireRate += 3;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElementA = element.plasma;
                break;
            case ammoModel.three:
                stats.damage += 6;
                stats.accuracy += 0;
                stats.recoil += -3;
                stats.durability += 0;
                stats.fireRate += 0;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElementA = element.fire;
                break;
            case ammoModel.four:
                stats.damage += 6;
                stats.accuracy += 0;
                stats.recoil += 0;
                stats.durability += 0;
                stats.fireRate += -5;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElementA = element.ice;
                break;
            case ammoModel.five:
                stats.damage += 3;
                stats.accuracy += 0;
                stats.recoil += 0;
                stats.durability += 0;
                stats.fireRate += 8;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElementA = element.electric;
                break;
            case ammoModel.six:
                stats.damage += 2;
                stats.accuracy += 0;
                stats.recoil += 0;
                stats.durability += 0;
                stats.fireRate += 9;
                stats.extraStatOne = " ";
                stats.extraStatTwo = " ";
                stats.myElementA = element.acid;
                break;
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

        myElementA = element.none;

    }

    public int GetCurPos()
    {
        return curPos;
    }

}