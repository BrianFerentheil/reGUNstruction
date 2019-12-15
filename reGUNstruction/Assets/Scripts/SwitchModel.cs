using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{

    public MeshFilter[] models;
    public int currentIndex;
    Ammo ammo;
    Grip grip;
    Barrel barrel;
    [SerializeField] GunModel model;

    void Awake()
    {
        ammo = gameObject.GetComponent<Ammo>();
        barrel = gameObject.GetComponent<Barrel>();
        grip = gameObject.GetComponent<Grip>();
        model = gameObject.GetComponentInParent<GunModel>();
    }

    public void SwapModelUp()
    {
        if (models.Length != 0)
        {
            currentIndex++;
            if (currentIndex >= models.Length)
                currentIndex = 0;
            gameObject.GetComponent<MeshFilter>().sharedMesh = models[currentIndex].sharedMesh;
            if(ammo != null)
            {
                ammo.NextPart();
                model.RunStats();
            }
            else if(grip != null)
            {
                grip.NextPart();
                model.RunStats();
            }
            else if(barrel != null)
            {
                barrel.NextPart();
                model.RunStats();
            }
        }
    }

    public void SwapModelDown()
    {
        if (models.Length != 0)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = models.Length - 1;
            gameObject.GetComponent<MeshFilter>().sharedMesh = models[currentIndex].sharedMesh;
            if (ammo != null)
            {
                ammo.LastPart();
                model.RunStats();
            }
            else if (grip != null)
            {
                grip.LastPart();
                model.RunStats();
            }
            else if (barrel != null)
            {
                barrel.LastPart();
                model.RunStats();
            }
        }
    }

    public void SetModel(int num)
    {
        if (num >= 0 && num < models.Length)
            gameObject.GetComponent<MeshFilter>().sharedMesh = models[num].sharedMesh;
        else
            Debug.Log("Model Index out of bounds");
    }

}
