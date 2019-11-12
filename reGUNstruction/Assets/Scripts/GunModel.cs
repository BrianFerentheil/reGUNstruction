using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GunModel : MonoBehaviour
{
    public Grip myGrip;
    public Barrel myBarrel;
    public Ammo myAmmo;

    public GunStats myStats;

    string[] myElements;

    public Material[] colors;

    public Text[] sliderTexts;

    //public TMP_Text tmproTx;

    // Start is called before the first frame update
    void Start()
    {
        myStats = new GunStats();
        FillColors();
        RunStats();
        SetColors();
        //tmproTx = GameObject.Find("TMPRO").GetComponent<TextMeshProUGUI>();
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

    void Slidertexts()
    {
        sliderTexts[0].text = myStats.damage.ToString();
        sliderTexts[1].text = myStats.accuracy.ToString();
        sliderTexts[2].text = myStats.recoil.ToString();
        sliderTexts[3].text = myStats.durability.ToString();
        sliderTexts[4].text = myStats.fireRate.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //tmproTx.text = myStats.damage + "\n" + myStats.accuracy + "\n" + myStats.recoil + "\n" + myStats.durability + "\n" + myStats.fireRate;

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
        //Debug.Log(myStats.damage + "-Damage,  " + myStats.accuracy + "-Accuracy,  " + myStats.recoil + " -Recoil,  " + myStats.durability + " -Durability,  " + myStats.fireRate + " -FireRate");
        //Debug.Log(myElements[0]+ myElements[1] +myElements[2]);
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
        RunStats();

    }
    public void PreviousPartBarrel()
    {
        myBarrel.LastPart();
        SetColors();
        RunStats();
    }
    public void PreviousPartAmmo()
    {
        myAmmo.LastPart();
        SetColors();
        RunStats();
    }

    public void NextPartGrip()
    {
        myGrip.NextPart();
        SetColors();
        RunStats();
    }
    public void NextPartBarrel()
    {
        myBarrel.NextPart();
        SetColors();
        RunStats();
    }
    public void NextPartAmmo()
    {
        myAmmo.NextPart();
        SetColors();
        RunStats();
    }

    public void SetColors()
    {
        //myGrip.GetComponent<Renderer>().material = colors[myGrip.GetCurPos()];
        //myBarrel.GetComponent<Renderer>().material = colors[myBarrel.GetCurPos()];
        //myAmmo.GetComponent<Renderer>().material = colors[myAmmo.GetCurPos()];
        Slidertexts();

        myGrip.swiMod.SetModel(myGrip.GetCurPos());
        myBarrel.swiMod.SetModel(myBarrel.GetCurPos());
        myAmmo.swiMod.SetModel(myAmmo.GetCurPos());


    }


    private void ElementArray()
    {
        myElements = new string[3];
        myElements[0] = myStats.myElementA.ToString();
        myElements[1] = myStats.myElementB.ToString();
        myElements[2] = myStats.myElementG.ToString();               
    }
}
