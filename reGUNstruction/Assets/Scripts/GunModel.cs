using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModel : MonoBehaviour
{
    public Grip myGrip;
    public Barrel myBarrel;
    public Ammo myAmmo;

    GunStats myStats;

    // Start is called before the first frame update
    void Start()
    {
        myStats = new GunStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            RunStats();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            RunStats();
        }
    }

    public void RunStats()
    {
        myStats.SetBaseParams();
        myGrip.RunStatMods(myGrip.currentGrip, myStats);
        myBarrel.RunStatMods(myBarrel.currentBarrel, myStats);
        myAmmo.RunStatMods(myAmmo.currentAmmo, myStats);

        //myStats.SetStats(myGrip.currentGrip,myAmmo.currentAmmo, myBarrel.currentBarrel);
        Debug.Log(myStats.damage + "-Damage,  " + myStats.accuracy + "-Accuracy,  " + myStats.recoil + " -Recoil,  " + myStats.durability + " -Durability,  " + myStats.fireRate + " -FireRate");
    }

    private void LastPart()
    {
        myGrip.LastPart();
        myBarrel.LastPart();
        myAmmo.LastPart();
    }

    private void NextPart()
    {
        myGrip.NextPart();
        myBarrel.NextPart();
        myAmmo.NextPart();
    }
}
