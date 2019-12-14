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
public class SwappingGunModel : MonoBehaviour
{
    [SerializeField] List<GameObject> bases;
    [SerializeField] GameObject currWeapon;
    [SerializeField] GunStatsSlider statSlider;
    Transform gunTransform;
    TheMachine machine;
    [SerializeField] GameObject craftingCanvas;

    void Start()
    {
        gunTransform = currWeapon.transform;

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
                        Debug.Log("Original Weapon: " + currWeapon.name);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Debug.Log("New Weapon: " + newGun.name);
                        Debug.Log("Old Weapon: " + Temp.name);
                        Destroy(Temp);
                        Debug.Log("Current Weapon: " + currWeapon.name);
                    }
                }
                break;
            case GunBase.AR:
                for (int i = 0; i < bases.Count; i++)
                {
                    if (bases[i].GetComponent<Weapon>().gunBase == GunBase.SG)
                    {
                        GameObject newGun = Instantiate(bases[i], currWeapon.transform.parent);
                        Debug.Log("Original Weapon: " + currWeapon.name);
                        newGun.transform.position = gunTransform.position;
                        newGun.transform.rotation = gunTransform.rotation;
                        GameObject Temp = currWeapon;
                        currWeapon = newGun;
                        currWeapon.GetComponent<Weapon>().spawnTransform = GameObject.Find("SpawnPoint").transform;
                        currWeapon.GetComponent<Weapon>().bulletShellSpawn = GameObject.Find("BulletShellSpawn").transform;
                        Debug.Log("New Weapon: " + newGun.name);
                        Debug.Log("Old Weapon: " + Temp.name);
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
        Debug.Log("Old Gun Destroyed");
        UpdateTheMachine();
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
        Debug.Log("Old Gun Destroyed");
        UpdateTheMachine();
    }

    void UpdateTheMachine()
    {
        TheMachine.weapon = currWeapon.GetComponent<Weapon>();
        gunTransform = currWeapon.transform;
        statSlider.SetWeapon(GameObject.FindWithTag("Gun").GetComponent<Weapon>());
        foreach (Button btn in craftingCanvas.GetComponentsInChildren<Button>())
        {
            Debug.Log("Swapping Function");
            if (btn.name.Contains("Grip"))
            {
                Debug.Log("Swapping Grip Function");
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
                if (btn.name.Contains("Next"))
                    btn.onClick.AddListener(delegate { ammoSwitch.SwapModelUp(); });
                else
                    btn.onClick.AddListener(delegate { ammoSwitch.SwapModelDown(); });
            }
        }
    }
}
