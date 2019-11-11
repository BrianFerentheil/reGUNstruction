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
        indexLength = System.Enum.GetValues(typeof(gripModel)).Length -1;
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
            curPos = indexLength -1;
        }

        currentGrip = (gripModel)curPos;
        return currentGrip;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LastPart();
            Debug.Log(indexLength + " " + curPos);
            Debug.Log((gripModel)curPos);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPart();
            Debug.Log(indexLength + " " + curPos);
            Debug.Log((gripModel)curPos);
        }
    }

}
