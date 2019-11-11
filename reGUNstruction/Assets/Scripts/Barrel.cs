using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public enum barrelModel { one, two, three, four, five, none }
    barrelModel currentBarrel = barrelModel.none;

    private int indexLength;
    private int curPos = 0;


    private void Start()
    {
        indexLength = System.Enum.GetValues(typeof(barrelModel)).Length -1;
    }

    public barrelModel NextPart()
    {
        curPos++;
        if (curPos >= indexLength)
        {
            curPos = 0;
        }

        currentBarrel = (barrelModel)curPos;
        return currentBarrel;
    }

    public barrelModel LastPart()
    {
        curPos--;
        if (curPos <= 0)
        {
            curPos = indexLength - 1;
        }

        currentBarrel = (barrelModel)curPos;
        return currentBarrel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            Debug.Log(indexLength + " " + curPos);
            Debug.Log((barrelModel)curPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            Debug.Log(indexLength + " " + curPos);
            Debug.Log((barrelModel)curPos);
        }
    }
}

