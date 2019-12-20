using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudio : MonoBehaviour
{
    AudioManager am;
    GameObject gun;
    string gunName;

    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        gun = GameObject.FindGameObjectWithTag("Gun");
        gunName = gun.name;
        am.PlayAudio(gunName);
        Debug.Log(gunName);
    }
}
