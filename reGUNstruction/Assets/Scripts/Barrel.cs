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
        indexLength = System.Enum.GetValues(typeof(barrelModel)).Length;
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
            curPos = indexLength;
        }

        currentBarrel = (barrelModel)curPos;
        return currentBarrel;
    }
}
