using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public enum ammoModel { one, two, three, four, five, none }
    ammoModel currentAmmo = ammoModel.none;

    private int indexLength;
    private int curPos = 0;
    
    private void Start()
    {
        indexLength = System.Enum.GetValues(typeof(ammoModel)).Length -1;
    }

    public ammoModel NextPart()
    {
        curPos++;
        if (curPos >= indexLength)
        {
            curPos = 0;
        }

        currentAmmo = (ammoModel)curPos;
        return currentAmmo;
    }

    public ammoModel LastPart()
    {
        curPos--;
        if (curPos < 0)
        {
            curPos = indexLength - 1;
        }

        currentAmmo = (ammoModel)curPos;
        return currentAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            Debug.Log(indexLength + " " + curPos);
            Debug.Log((ammoModel)curPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            Debug.Log(indexLength + " " + curPos);
            Debug.Log((ammoModel)curPos);
        }
    }
}