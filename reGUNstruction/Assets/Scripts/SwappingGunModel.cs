using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingGunModel : MonoBehaviour
{
    List<GameObject> bases;
    [SerializeField] GameObject currWeapon;
    Transform gunTransform;
    void Start()
    {
        gunPos = currWeapon.transform;
    }

    public void LoadAR()
    {

    }

    public void LoadShotgun()
    {

    }

    public void LoadMG()
    {

    }

    public void LoadOtherGun()
    {

    }
}
