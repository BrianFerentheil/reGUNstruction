﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{

    public MeshFilter[] models;
    int currentIndex;
    Ammo ammo;
    Grip grip;
    Barrel barrel;
    [SerializeField] GunModel model;
    [SerializeField] SwappingGunModel swapper;

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void SetCurrentIndex(int index)
    {
        currentIndex = index;
        int i = 0;
        if (ammo != null)
            for (i = 0; i < index; i++)
                ammo.NextPart();
        else if (grip != null)
            for (i = 0; i < index; i++)
                grip.NextPart();
        else if (barrel != null)
            for (i = 0; i < index; i++)
                barrel.NextPart();
    }

    public ComponentType GetComponentType()
    {
        if (ammo != null)
            return ComponentType.ammo;
        else if (grip != null)
            return ComponentType.grip;
        else if (barrel != null)
            return ComponentType.barrel;
        return ComponentType.none;
    }

    void Awake()
    {
        ammo = gameObject.GetComponent<Ammo>();
        barrel = gameObject.GetComponent<Barrel>();
        grip = gameObject.GetComponent<Grip>();
        model = gameObject.GetComponentInParent<GunModel>();
        swapper = GameObject.Find("Gun Swapper").GetComponent<SwappingGunModel>();
    }

    public void SwapModelUp()
    {
        if (models.Length != 0)
        {
            currentIndex++;
            if (currentIndex >= models.Length)
                currentIndex = 0;
            gameObject.GetComponent<MeshFilter>().sharedMesh = models[currentIndex].sharedMesh;
            if (ammo != null)
            {
                ammo.NextPart();
                model.RunStats();
            }
            else if (grip != null)
            {
                grip.NextPart();
                model.RunStats();
            }
            else if (barrel != null)
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

    void OnDestroy()
    {
        if (ammo != null)
            swapper.SetAmmo(currentIndex);
        else if (grip != null)
            swapper.SetGrip(currentIndex);
        else if (barrel != null)
            swapper.SetBarrel(currentIndex);
    }

}
