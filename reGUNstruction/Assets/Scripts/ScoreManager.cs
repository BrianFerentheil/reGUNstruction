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
    private float multiplier;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreCheck()
    {
        if(currentScore >= startToAddMultiplier)
        {
            currentScore = currentScore * multiplier;
            startToAddMultiplier = startToAddMultiplier + bounceGap;
            multiplier = multiplier + multiplierGap;

        }
        else
        {
            return;
        }
    }
}
