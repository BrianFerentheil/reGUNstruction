using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParts : GunStats
{
    [SerializeField] protected enum gunPiece { grip, ammo, barrel, none}
    protected gunPiece thisPart;
    protected float myNum;
    
}

public class GunPartGrip : GunParts     
{
    gunPiece thisPart = gunPiece.grip;
    gripModel thisGrip = gripModel.one;
          
}

public class GunPartAmmo : GunParts
{
    gunPiece thisPart = gunPiece.ammo;
    ammoModel thisAmmo = ammoModel.one;

}

public class GunPartBarrel : GunParts
{
    gunPiece thisPart = gunPiece.barrel;
    barrelModel thisBarrel = barrelModel.one;
}