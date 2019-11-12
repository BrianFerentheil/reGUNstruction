using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModel : MonoBehaviour
{
    public Grip myGrip;
    public Barrel myBarrel;
    public Ammo myAmmo;

    GunStats myStats;

    string[] myElements;

    public Material[] colors;

    // Start is called before the first frame update
    void Start()
    {
        myStats = new GunStats();
        FillColors();
    }

    void FillColors()
    {
        colors = new Material[5];
        colors[0] = Resources.Load<Material>("Materials/Red");
        colors[1] = Resources.Load<Material>("Materials/Blue");
        colors[2] = Resources.Load<Material>("Materials/Gold");
        colors[3] = Resources.Load<Material>("Materials/Purple");
        colors[4] = Resources.Load<Material>("Materials/LimeGreen");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPartAll();
            RunStats();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPartAll();
            RunStats();
        }
    }

    public void RunStats()
    {
        myStats.SetBaseParams();
        myGrip.RunStatMods(myGrip.currentGrip, myStats);
        myBarrel.RunStatMods(myBarrel.currentBarrel, myStats);
        myAmmo.RunStatMods(myAmmo.currentAmmo, myStats);
        ElementArray();

        //myStats.SetStats(myGrip.currentGrip,myAmmo.currentAmmo, myBarrel.currentBarrel);
        Debug.Log(myStats.damage + "-Damage,  " + myStats.accuracy + "-Accuracy,  " + myStats.recoil + " -Recoil,  " + myStats.durability + " -Durability,  " + myStats.fireRate + " -FireRate");
        Debug.Log(myElements[0]+ myElements[1] +myElements[2]);
    }

    private void LastPartAll()
    {
        myGrip.LastPart();
        myBarrel.LastPart();
        myAmmo.LastPart();
    }

    private void NextPartAll()
    {
        myGrip.NextPart();
        myBarrel.NextPart();
        myAmmo.NextPart();
    }

    public void PreviousPartGrip()
    {
        myGrip.LastPart();
        SetColors();
    }
    public void PreviousPartBarrel()
    {
        myBarrel.LastPart();
        SetColors();

    }
    public void PreviousPartAmmo()
    {
        myAmmo.LastPart();
        SetColors();

    }

    public void NextPartGrip()
    {
        myGrip.NextPart();
        SetColors();

    }
    public void NextPartBarrel()
    {
        myBarrel.NextPart();
        SetColors();

    }
    public void NextPartAmmo()
    {
        myAmmo.NextPart();
        SetColors();

    }

    public void SetColors()
    {
        myGrip.GetComponent<Renderer>().material = colors[myGrip.GetCurPos()];
        myBarrel.GetComponent<Renderer>().material = colors[myBarrel.GetCurPos()];
        myAmmo.GetComponent<Renderer>().material = colors[myAmmo.GetCurPos()];

    }


    private void ElementArray()
    {
        myElements = new string[3];
        myElements[0] = myStats.myElementA.ToString();
        myElements[1] = myStats.myElementB.ToString();
        myElements[2] = myStats.myElementG.ToString();               
    }
}
