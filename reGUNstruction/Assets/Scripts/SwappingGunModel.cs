using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GunBase
{
    P,
    AR,
    SG,
    MG,
    COUNT
}

public enum ComponentType
{
    ammo,
    barrel,
    grip,
    none
}

public class SwappingGunModel : MonoBehaviour
{
    [SerializeField] List<GameObject> bases;
    [SerializeField] GameObject currWeapon;
    [SerializeField] GunStatsSlider statSlider;
    Transform gunTransform;
    TheMachine machine;
    [SerializeField] GameObject craftingCanvas;
    bool update = false;
    [SerializeField] int currentGrip = 0;
    [SerializeField] int currentAmmo = 0;
    [SerializeField] int currentBarrel = 0;
    
    public void SetGrip(int index)
    {
        currentGrip = index;
    }

    public void SetAmmo(int index)
    {
        currentAmmo = index;
    }

    public void SetBarrel(int index)
    {
        currentBarrel = index;
    }

    void Start()
    {
        gunTransform = currWeapon.transform;

    }
    void Update()
    {
        if (update)
        {
            UpdateTheMachine();
            update = false;
        }
    }
    public void SwitchGunUp()
    {
        switch (currWeapon.GetComponent<Weapon>().gunBase)
        {
            case GunBase.P:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.AR)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            case GunBase.AR:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.SG)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            case GunBase.SG:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.MG)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            case GunBase.MG:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.P)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            default:
                break;
        }

        StartCoroutine("DelayUpdate");
    }

    public void SwitchGunDown()
    {
        switch (currWeapon.GetComponent<Weapon>().gunBase)
        {
            case GunBase.P:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.MG)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            case GunBase.AR:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.P)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            case GunBase.SG:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.AR)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            case GunBase.MG:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.SG)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Destroy(Temp);
                    }
                }
                break;
            default:
                break;
        }

        StartCoroutine("DelayUpdate");
    }

    IEnumerator DelayUpdate()
    {
        yield return new WaitForSeconds(.2f);
        update = true;
        yield return new WaitForSeconds(0);
    }

    void UpdateTheMachine()
    {
        TheMachine.weapon = currWeapon.GetComponent<Weapon>();
        TheMachine.weapon.enabled = false;
        gunTransform = currWeapon.transform;
        statSlider.SetWeapon(GameObject.FindWithTag("Gun").GetComponent<Weapon>());
        foreach (Button btn in craftingCanvas.GetComponentsInChildren<Button>())
        {
            btn.onClick.RemoveAllListeners();
            if (btn.name.Contains("Grip"))
            {
                GameObject grip = GameObject.Find("Grip");
                Debug.Log(grip.name);
                SwitchModel gripSwitch = grip.GetComponent<SwitchModel>();
                if (btn.name.Contains("Next"))
                {
                    btn.onClick.AddListener(delegate { gripSwitch.SwapModelUp(); });
                    Debug.Log("Swap Up Function Added");
                }
                else
                    btn.onClick.AddListener(delegate { gripSwitch.SwapModelDown(); });
            }
            else if (btn.name.Contains("Barrel"))
            {
                GameObject barrel = GameObject.Find("Barrel");
                SwitchModel barrelSwitch = barrel.GetComponent<SwitchModel>();
                if (btn.name.Contains("Next"))
                    btn.onClick.AddListener(delegate { barrelSwitch.SwapModelUp(); });
                else
                    btn.onClick.AddListener(delegate { barrelSwitch.SwapModelDown(); });
            }
            else if (btn.name.Contains("Ammo"))
            {
                GameObject ammo = GameObject.Find("Ammo");
                SwitchModel ammoSwitch = ammo.GetComponent<SwitchModel>();
                if (ammoSwitch != null)
                {
                    if (btn.name.Contains("Next"))
                        btn.onClick.AddListener(() => { ammoSwitch.SwapModelUp(); });
                    else
                        btn.onClick.AddListener(() => { ammoSwitch.SwapModelDown(); });
                }
                else
                    Debug.Log("Switcher Doesn't Exist.");
            }
        }
        Debug.Log("Current Ammo: " + currentAmmo);
        foreach(SwitchModel comp in currWeapon.GetComponentsInChildren<SwitchModel>())
        {
            GameObject component = comp.gameObject;
            Debug.Log("Correcting index");
            switch (comp.GetComponentType())
            {
                case ComponentType.ammo:
                    comp.SetCurrentIndex(currentAmmo);
                    break;
                case ComponentType.grip:
                    comp.SetCurrentIndex(currentGrip);
                    break;
                case ComponentType.barrel:
                    comp.SetCurrentIndex(currentBarrel);
                    break;
                case ComponentType.none:
                    break;
                default:
                    break;
            }
        }

        currWeapon.GetComponent<GunModel>().RunStats();
    }
}
