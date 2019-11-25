using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStatsSlider : MonoBehaviour
{
    GunModel gunModel;

    public Slider damage;
    public GameObject damageFill;
    public Text damText;
    public Slider fireRate;
    public GameObject fireRateFill;
    public Text fRText;
    public Text scoreText;

    Weapon weapon;
    Color damageColor;
    ScoreManager scoreManager;

    void Start()
    {
        gunModel = FindObjectOfType<GunModel>();
        weapon = FindObjectOfType<Weapon>();
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreText = FindObjectOfType<ButtonManager>().scoreCanvas.transform.GetChild(0).GetComponent<Text>();
        scoreText.text = "";
    }

    
    void Update()
    {
        UpdateSlider();
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + scoreManager.currentScore.ToString();
    }

    public void UpdateSlider()
    {
        //damage.value = gunModel.myStats.damage;
        switch (weapon.dRng)
        {
            case GunModel.damageRange.low:
                damageColor = Color.green;
                damage.value = 1;
                damText.text = "Range: 1";
                damText.color = Color.green;
                break;
            case GunModel.damageRange.med:
                damageColor = Color.yellow;
                damage.value = 2;
                damText.text = "Range: 2";
                damText.color = Color.yellow;
                break;
            case GunModel.damageRange.high:
                damageColor = Color.red;
                damage.value = 3;
                damText.text = "Range: 3";
                damText.color = Color.red;
                break;
            case GunModel.damageRange.none:
                damageColor = Color.clear;
                break;
            default:
                break;
        }
        damageFill.GetComponent<Image>().color = damageColor;


        //fireRate.value = gunModel.myStats.fireRate;
        

        switch (weapon.bSpd)
        {
            case GunModel.bulletSpeed.low:
                fireRateFill.GetComponent<Image>().color = Color.green;
                fireRate.value = 1;
                fRText.text = "2 BPS";
                fRText.color = Color.green;
                break;
            case GunModel.bulletSpeed.med:
                fireRateFill.GetComponent<Image>().color = Color.yellow;
                fireRate.value = 2;
                fRText.text = "4 BPS";
                fRText.color = Color.yellow;
                break;
            case GunModel.bulletSpeed.fast:
                fireRateFill.GetComponent<Image>().color = Color.red;
                fireRate.value = 3;
                fRText.text = "6 BPS";
                fRText.color = Color.red;
                break;
            case GunModel.bulletSpeed.none:
                break;
            default:
                break;
        }
    }
}
