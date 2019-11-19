using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStatsSlider : MonoBehaviour
{
    GunModel gunModel;

    public Slider damage;
    public GameObject damageFill;
    public Slider fireRate;
    public GameObject fireRateFill;

    Weapon weapon;
    Color damageColor;

    void Start()
    {
        gunModel = FindObjectOfType<GunModel>();
        weapon = FindObjectOfType<Weapon>();
    }

    
    void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        damage.value = gunModel.myStats.damage;
        switch (weapon.dRng)
        {
            case GunModel.damageRange.low:
                damageColor = Color.green;
                break;
            case GunModel.damageRange.med:
                damageColor = Color.yellow;
                break;
            case GunModel.damageRange.high:
                damageColor = Color.red;
                break;
            case GunModel.damageRange.none:
                damageColor = Color.clear;
                break;
            default:
                break;
        }
        damageFill.GetComponent<Image>().color = damageColor;




        fireRate.value = gunModel.myStats.fireRate;
        

        switch (weapon.bSpd)
        {
            case GunModel.bulletSpeed.low:
                fireRateFill.GetComponent<Image>().color = Color.green;
                break;
            case GunModel.bulletSpeed.med:
                fireRateFill.GetComponent<Image>().color = Color.yellow;
                break;
            case GunModel.bulletSpeed.fast:
                fireRateFill.GetComponent<Image>().color = Color.red;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }
    }
}
