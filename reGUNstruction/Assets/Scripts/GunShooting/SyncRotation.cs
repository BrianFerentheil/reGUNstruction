using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncRotation : MonoBehaviour
{

    public GameObject parent;
    void Start()
    {
        //parent = FindObjectOfType<Weapon>();
    }

    void Update()
    {
        this.transform.rotation = parent.transform.rotation;
    }
}
