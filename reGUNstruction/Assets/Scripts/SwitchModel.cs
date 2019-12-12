using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{

    public MeshFilter[] models;
    public int currentIndex;

    public void SwapModelUp()
    {
        if (models.Length != 0)
        {
            currentIndex++;
            if (currentIndex > models.Length)
                currentIndex = 0;
            gameObject.GetComponent<MeshFilter>().mesh = models[currentIndex].mesh;
        }
    }

    public void SwapModelDown()
    {
        if (models.Length != 0)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = models.Length - 1;
            gameObject.GetComponent<MeshFilter>().mesh = models[currentIndex].mesh;
        }
    }

    public void SetModel(int num)
    {
        if (num >= 0 && num < models.Length)
            gameObject.GetComponent<MeshFilter>().sharedMesh = models[num].mesh;
    }

}
