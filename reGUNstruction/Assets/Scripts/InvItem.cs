using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvItem : MonoBehaviour
{

    public static List<GunStats> allParts = new List<GunStats>();

    GunStats me;

    public Grip.gripModel grip = Grip.gripModel.none;
    public Barrel.barrelModel barrel = Barrel.barrelModel.none;
    public Ammo.ammoModel ammo = Ammo.ammoModel.none;

    public Grip myGrip;
    public Barrel myBarrel;
    public Ammo myAmmo;

    public GameObject fRObj;
    public GameObject dObj;

    public Slider damageSlider;
    public Slider fireRateSlider;

    public Image damSliFill;
    public Image firSliFill;

    public GameObject partUI;
    public bool uiSet;

    // Start is called before the first frame update
    void Start()
    {
        me = new GunStats();
        partUI = Resources.Load<GameObject>("Prefabs/GunCanvas");
        
        if(grip != Grip.gripModel.none)
        {
            myGrip = new Grip();
            myGrip.RunStatMods(grip, me);

            switch (grip)
            {
                case Grip.gripModel.pistol:
                    break;
                case Grip.gripModel.subMG:
                    break;
                case Grip.gripModel.assaultR:
                    break;
                case Grip.gripModel.shotG:
                    break;
                case Grip.gripModel.none:
                    break;
                default:
                    break;
            }
            
        }
        else if(barrel != Barrel.barrelModel.none)
        {
            myBarrel = new Barrel();
            myBarrel.RunStatMods(barrel, me);

            switch (barrel)
            {
                case Barrel.barrelModel.one:
                    break;
                case Barrel.barrelModel.two:
                    break;
                case Barrel.barrelModel.three:
                    break;
                case Barrel.barrelModel.four:
                    break;
                case Barrel.barrelModel.five:
                    break;
                case Barrel.barrelModel.six:
                    break;
                case Barrel.barrelModel.seven:
                    break;
                case Barrel.barrelModel.none:
                    break;
                default:
                    break;
            }
        }
        else if(ammo != Ammo.ammoModel.none)
        {
            myAmmo = new Ammo();
            myAmmo.RunStatMods(ammo, me);

            switch (ammo)
            {
                case Ammo.ammoModel.one:
                    break;
                case Ammo.ammoModel.two:
                    break;
                case Ammo.ammoModel.three:
                    break;
                case Ammo.ammoModel.four:
                    break;
                case Ammo.ammoModel.five:
                    break;
                case Ammo.ammoModel.six:
                    break;
                case Ammo.ammoModel.seven:
                    break;
                case Ammo.ammoModel.eight:
                    break;
                case Ammo.ammoModel.nine:
                    break;
                case Ammo.ammoModel.ten:
                    break;
                case Ammo.ammoModel.eleven:
                    break;
                case Ammo.ammoModel.none:
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  WhichPartIsThis()
    {
        if (name.Contains("Grip"))
        {
            if (name.Contains("One"))
            {
                grip = Grip.gripModel.pistol;
            }
            else if (name.Contains("Two"))
            {
                grip = Grip.gripModel.subMG;

            }
            else if (name.Contains("Three"))
            {
                grip = Grip.gripModel.assaultR;

            }
            else if (name.Contains("Four"))
            {
                grip = Grip.gripModel.shotG;

            }
        }
        else if (name.Contains("Barrel"))
        {
            if (name.Contains("One"))
            {
                barrel = Barrel.barrelModel.one;
            }
            else if (name.Contains("Two"))
            {
                barrel = Barrel.barrelModel.two;

            }
            else if (name.Contains("Three"))
            {
                barrel = Barrel.barrelModel.three;

            }
            else if (name.Contains("Four"))
            {
                barrel = Barrel.barrelModel.four;

            }
            else if (name.Contains("Five"))
            {
                barrel = Barrel.barrelModel.five;

            }
            else if (name.Contains("Six"))
            {
                barrel = Barrel.barrelModel.six;

            }
            else if (name.Contains("Seven"))
            {
                barrel = Barrel.barrelModel.seven;

            }
        }
        else if (name.Contains("Ammo"))
        {
            if (name.Contains("One"))
            {
                ammo = Ammo.ammoModel.one;
            }
            else if (name.Contains("Two"))
            {
                ammo = Ammo.ammoModel.two;

            }
            else if (name.Contains("Three"))
            {
                ammo = Ammo.ammoModel.three;

            }
            else if (name.Contains("Four"))
            {
                ammo = Ammo.ammoModel.four;

            }
            else if (name.Contains("Five"))
            {
                ammo = Ammo.ammoModel.five;

            }
            else if (name.Contains("Six"))
            {
                ammo = Ammo.ammoModel.six;

            }
            else if (name.Contains("Seven"))
            {
                ammo = Ammo.ammoModel.seven;

            }
            else if (name.Contains("Eight"))
            {
                ammo = Ammo.ammoModel.eight;

            }
            else if (name.Contains("Nine"))
            {
                ammo = Ammo.ammoModel.nine;

            }
            else if (name.Contains("Ten"))
            {
                ammo = Ammo.ammoModel.ten;

            }
            else if (name.Contains("Eleven"))
            {
                ammo = Ammo.ammoModel.eleven;

            }
        }
        else
        {
            Debug.Log("Name Contains Error");
        }
    }

    void FillUI()
    {
        fireRateSlider = fRObj.GetComponent<Slider>();
        damageSlider = dObj.GetComponent<Slider>();

        firSliFill = fRObj.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        damSliFill = dObj.transform.GetChild(1).GetChild(0).GetComponent<Image>();


    }

    public void UpdateUI()
    {
        damageSlider.value = me.damage;
        fireRateSlider.value = me.fireRate;

        Debug.Log($"Damage {me.damage} , FireRate {me.fireRate} , My Stats");
    }

    public void OpenUI()
    {
        if (!uiSet)
        {
            GameObject temp = Instantiate<GameObject>(partUI, transform);
            partUI = temp;

            fRObj = partUI.transform.GetChild(1).gameObject;
            dObj = partUI.transform.GetChild(2).gameObject;

            FillUI();
            UpdateUI();
            uiSet = true;
        }
        else
        {
            partUI.SetActive(true);
        }
    }

    public void CloseUI()
    {
        partUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            CloseUI();
        }
    }
}
