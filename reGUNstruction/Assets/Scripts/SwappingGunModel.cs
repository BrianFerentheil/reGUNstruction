using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    Transform gunTransform;
    TheMachine machine;
    void Start()
    {
        gunTransform = currWeapon.transform;
    }

    void LoadAR()
    {

    }

    void LoadShotgun()
    {

    }

    void LoadMG()
    {

    }

    void LoadOtherGun()
    {

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
        UpdateTheMachine();
    }

    void UpdateTheMachine()
    {
        TheMachine.weapon = currWeapon.GetComponent<Weapon>();
        gunTransform = currWeapon.transform;
    }
}
