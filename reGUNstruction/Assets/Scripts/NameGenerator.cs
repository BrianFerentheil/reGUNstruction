using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    public string[] gripNameArray;
    public string[] middleNameArray;
    public string[] lastNameArray;
    public string GripName;
    public string BarrelName;
    public string AmmoName;
    public UnityEngine.UI.Text GripNameText;
    public UnityEngine.UI.Text BarrelNameText;
    public UnityEngine.UI.Text AmmoNameText;


    // Start is called before the first frame update
    void Start()
    {
        GripName = gripNameArray[Random.Range(0, gripNameArray.Length)];
        BarrelName = middleNameArray[Random.Range(0, gripNameArray.Length)];
        AmmoName = lastNameArray[Random.Range(0, gripNameArray.Length)];
        GripNameText.text = GripName.ToString();
        BarrelNameText.text = BarrelName.ToString();
        AmmoNameText.text = AmmoName.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
