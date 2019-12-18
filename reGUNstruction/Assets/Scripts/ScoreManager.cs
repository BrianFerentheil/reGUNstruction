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
    


    PlayerScoreSystem pSS;
    

    void Start()
    {
        multiplier = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            currentScore += 100000;
        }
    }

    public void ScoreCheck()
    {
        if(multiplier >= multiplierMax)
        {
            multiplier = multiplierMax;
        }
        if (currentScore >= startToAddMultiplier)
        {
            multiplier = multiplier + multiplierGap;
        }
        else
        {
            return;
        }
    }

    //This function is called between rounds  to add the current total to the player's saved total - then will reset their current total.
    public void ResetScore()
    {
        if(pSS == null)
        {
            pSS = FindObjectOfType<PlayerScoreSystem>();
        }

        pSS.AddToTotal(currentScore);
        currentScore = 0;
    }
}
