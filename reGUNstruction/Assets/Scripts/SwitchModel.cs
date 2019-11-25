﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{

    public MeshFilter[] models;
    public int currentIndex;

    //public void SwapModelUp()
    //{
    //    currentIndex++;
    //    if (currentIndex > models.Count)
    //        currentIndex = 0;
    //    gameObject.GetComponent<MeshFilter>().mesh = models[currentIndex].mesh;
    //}

    //public void SwapModelDown()
    //{
    //    currentIndex--;
    //    if (currentIndex < 0)
    //        currentIndex = models.Count - 1;
    //    gameObject.GetComponent<MeshFilter>().mesh = models[currentIndex].mesh;
    //}

    private void Start()
    {
        
    }

    public void SetModel(int num)
    {
        gameObject.GetComponent<MeshFilter>().sharedMesh = models[num].mesh;
    }

}
