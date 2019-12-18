using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvItem : MonoBehaviour
{

    //public static List<GunStats> allParts = new List<GunStats>();

    GunStats me;

    public int purchaseCost;

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

    public TMP_Text ownText;
    public TMP_Text frText;
    public TMP_Text dText;

    public static bool arraysFilled;
    public static bool[] invGrips;
    public static bool[] invBarrels;
    public static bool[] invAmmos;

    int myPos;
    string myType;

    public bool owned;

    public bool playerClose;


    // Start is called before the first frame update
    void Start()
    {
        me = new GunStats();
        partUI = Resources.Load<GameObject>("Prefabs/GunCanvas");
        WhichPartIsThis();
        
        if(grip != Grip.gripModel.none)
        {
            myGrip = new Grip();
            myGrip.RunStatMods(grip, me);            
        }
        else if(barrel != Barrel.barrelModel.none)
        {
            myBarrel = new Barrel();
            myBarrel.RunStatMods(barrel, me);
        }
        else if(ammo != Ammo.ammoModel.none)
        {
            myAmmo = new Ammo();
            myAmmo.RunStatMods(ammo, me);
        }

        FillInvArrays();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerClose)
        {
            if(purchaseCost < PlayerScoreSystem.totalScore)
            {
                PurchaseInv();
            }
        }
    }

    void  WhichPartIsThis()
    {
        if (name.Contains("Grip"))
        {
            myType = "grip";
            if (name.Contains("One"))
            {
                grip = Grip.gripModel.pistol;
                myPos = 0;                
            }
            else if (name.Contains("Two"))
            {
                grip = Grip.gripModel.subMG;
                myPos = 1;
            }
            else if (name.Contains("Three"))
            {
                grip = Grip.gripModel.assaultR;
                myPos = 2;
            }
            else if (name.Contains("Four"))
            {
                grip = Grip.gripModel.shotG;
                myPos = 3;
            }
        }
        else if (name.Contains("Barrel"))
        {
            myType = "barrel";

            if (name.Contains("One"))
            {
                barrel = Barrel.barrelModel.one;
                myPos = 0;
            }
            else if (name.Contains("Two"))
            {
                barrel = Barrel.barrelModel.two;
                myPos = 1;
            }
            else if (name.Contains("Three"))
            {
                barrel = Barrel.barrelModel.three;
                myPos = 2;
            }
            else if (name.Contains("Four"))
            {
                barrel = Barrel.barrelModel.four;
                myPos = 3;
            }
            else if (name.Contains("Five"))
            {
                barrel = Barrel.barrelModel.five;
                myPos = 4;
            }
            else if (name.Contains("Six"))
            {
                barrel = Barrel.barrelModel.six;
                myPos = 5;
            }
            else if (name.Contains("Seven"))
            {
                barrel = Barrel.barrelModel.seven;
                myPos = 6;
            }
        }
        else if (name.Contains("Ammo"))
        {
            myType = "ammo";

            if (name.Contains("One"))
            {
                ammo = Ammo.ammoModel.one;
                myPos = 0;
            }
            else if (name.Contains("Two"))
            {
                ammo = Ammo.ammoModel.two;
                myPos = 1;
            }
            else if (name.Contains("Three"))
            {
                ammo = Ammo.ammoModel.three;
                myPos = 2;
            }
            else if (name.Contains("Four"))
            {
                ammo = Ammo.ammoModel.four;
                myPos = 3;
            }
            else if (name.Contains("Five"))
            {
                ammo = Ammo.ammoModel.five;
                myPos = 4;
            }
            else if (name.Contains("Six"))
            {
                ammo = Ammo.ammoModel.six;
                myPos = 5;
            }
            else if (name.Contains("Seven"))
            {
                ammo = Ammo.ammoModel.seven;
                myPos = 6;
            }
            else if (name.Contains("Eight"))
            {
                ammo = Ammo.ammoModel.eight;
                myPos = 7;
            }
            else if (name.Contains("Nine"))
            {
                ammo = Ammo.ammoModel.nine;
                myPos = 8;
            }
            else if (name.Contains("Ten"))
            {
                ammo = Ammo.ammoModel.ten;
                myPos = 9;
            }
            else if (name.Contains("Eleven"))
            {
                ammo = Ammo.ammoModel.eleven;
                myPos = 10;
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

        frText = fRObj.transform.GetChild(3).GetComponent<TMP_Text>();
        dText = dObj.transform.GetChild(3).GetComponent<TMP_Text>();

        ownText = partUI.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();

    }

    public void UpdateUI()
    {
        damageSlider.value = me.damage;
        fireRateSlider.value = me.fireRate;

        frText.text = $"Fire Rate";
        dText.text = $"Damage";

        if (owned)
        {
            ownText.text = "Owned";
        }
        else
        {
            ownText.text = $"{purchaseCost} Points";
        }
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

        playerClose = true;
    }

    public void CloseUI()
    {
        partUI.SetActive(false);

        playerClose = false;
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

    void FillInvArrays()
    {
        if (!arraysFilled)
        {
            arraysFilled = true;
            invGrips = new bool[] { true, false, false, false };
            invBarrels = new bool[] { true, true, true, false, false, false, false };
            invAmmos = new bool[] { true, true, true, false, false, false, false, false, false, false, false };
        }
        InitialSetUp();
    }

    void InitialSetUp()
    {
        if (myType == "grip")
        {
            if (invGrips[myPos])
            {
                owned = true;
            }
        }
        else if (myType == "barrel")
        {
            if (invBarrels[myPos])
            {
                owned = true;
            }
        }
        else if (myType == "ammo")
        {
            if (invAmmos[myPos])
            {
                owned = true;
            }
        }
    }


    public void PurchaseInv()
    {
        if (!owned)
        {
            owned = true;
            PlayerScoreSystem.pss.SubtractFromScore(purchaseCost);

            if (myType == "grip")
            {
                invGrips[myPos] = true;
            }
            else if (myType == "barrel")
            {
                invBarrels[myPos] = true;
            }
            else if (myType == "ammo")
            {
                invAmmos[myPos] = true;
            }
        }
        UpdateUI();
    }
}
