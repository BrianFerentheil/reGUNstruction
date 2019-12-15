using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    ScoreManager sm;
    public float point;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        sm.currentScore = sm.currentScore + point;
    }
}
