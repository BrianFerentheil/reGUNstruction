using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{

    [SerializeField] List<MeshFilter> models;
    int currentIndex;

    public void SwapModelUp()
    {
        currentIndex++;
        if (currentIndex > models.Count)
            currentIndex = 0;
        gameObject.GetComponent<MeshFilter>().mesh = models[currentIndex].mesh;
    }

    public void SwapModelDown()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = models.Count - 1;
        gameObject.GetComponent<MeshFilter>().mesh = models[currentIndex].mesh;
    }

}
