using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public float currentScore;
    public float startToAddMultiplier;
    public float bounceGap;
    public float multiplierGap;
    public float multiplier;
    public float multiplierMax;

    void Start()
    {
        multiplier = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreCheck()
    {
        if(multiplier >= multiplierMax)
        {
            multiplier = multiplierMax;
        }
        if (currentScore >= startToAddMultiplier)
        {
            //currentScore = currentScore + (currentScore * multiplier);
            //startToAddMultiplier = startToAddMultiplier + bounceGap;
            multiplier = multiplier + multiplierGap;

        }
        else
        {
            return;
        }
    }
}
