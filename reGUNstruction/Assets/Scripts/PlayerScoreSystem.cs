using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreSystem : MonoBehaviour
{

    public static float totalScore;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTotal(float score)
    {
        totalScore += score;
    }

    public void SubtractFromScore(float cost)
    {
        totalScore -= cost;
    }
}
