using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStatsSlider : MonoBehaviour
{
    GunModel gunModel;

    public Slider damage;
    public Slider accuracy;
    public Slider recoil;
    public Slider durability;
    public Slider fireRate;

    void Start()
    {
        gunModel = FindObjectOfType<GunModel>();
    }

    
    void Update()
    {
        damage.value = gunModel.myStats.damage;
        accuracy.value = gunModel.myStats.accuracy;
        recoil.value = gunModel.myStats.recoil;
        durability.value = gunModel.myStats.durability;
        fireRate.value = gunModel.myStats.fireRate;
    }
}
