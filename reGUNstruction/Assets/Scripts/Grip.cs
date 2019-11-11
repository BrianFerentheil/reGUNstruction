using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip : MonoBehaviour
{
    public enum gripModel { one, two, three, four, five, none }
    gripModel currentGrip = gripModel.none;
    private int indexLength;
    private int curPos = 0;


    private void Start()
    {
        indexLength = System.Enum.GetValues(typeof(gripModel)).Length;
    }

    public gripModel NextPart()
    {
        curPos++;
        if(curPos >= indexLength)
        {
            curPos = 0;
        }

        currentGrip = (gripModel)curPos;
        return currentGrip;
    }

    public gripModel LastPart()
    {
        curPos--;
        if (curPos <= 0)
        {
            curPos = indexLength;
        }

        currentGrip = (gripModel)curPos;
        return currentGrip;
    }

}
