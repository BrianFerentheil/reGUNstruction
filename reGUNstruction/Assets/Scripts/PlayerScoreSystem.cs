using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreSystem : MonoBehaviour
{

    public static float totalScore;

    public static float highScore;

    TMP_Text totalScoreText;
    TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        totalScoreText = FindObjectOfType<TotalScoreUI>().GetComponent<TMP_Text>();
        highScoreText = FindObjectOfType<HighScoreUI>().GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTotal(float score)
    {
        CheckHighScore(score);
        totalScore += score;
        totalScoreText.text = $"Total Score: {totalScore}";
    }

    public void SubtractFromScore(float cost)
    {
        totalScore -= cost;
        totalScoreText.text = $"Total Score: {totalScore}";

    }

    public void CheckHighScore(float score)
    {
        if(highScore < score)
        {
            highScore = score;
            highScoreText.text = $"High Score: {highScore}";
        }
    }
}
