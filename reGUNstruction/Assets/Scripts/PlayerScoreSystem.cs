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

    public static PlayerScoreSystem pss;
    public float timerDuration = 1f;

    bool counting;
    float countingVar;

    // Start is called before the first frame update
    void Start()
    {
        totalScoreText = FindObjectOfType<TotalScoreUI>().GetComponent<TMP_Text>();
        highScoreText = FindObjectOfType<HighScoreUI>().GetComponent<TMP_Text>();

        pss = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTotal(float score, float total)
    {
        CheckHighScore(total);
        //totalScore += score;
        StartCoroutine("CountUpTotal", score + totalScore);
        //totalScoreText.text = $"Total Score: {totalScore}";
    }

    public void SubtractFromScore(float cost)
    {
        //totalScore -= cost;
        //totalScoreText.text = $"Total Score: {totalScore}";
        StartCoroutine("CountUpTotal", totalScore - cost);

    }

    public void CheckHighScore(float score)
    {
        if(highScore < score)
        {
            //highScore = score;
            //highScoreText.text = $"High Score: {highScore}";
            StartCoroutine("CountUpHigh", score);            
        }
    }

    public IEnumerator CountUpTotal(float newScore)
    {
        float start;
        if (!counting)
        {
            start = totalScore;
            countingVar = newScore;
            counting = true;
        }
        else
        {
            start = totalScore;
            newScore += countingVar - totalScore;
            countingVar = newScore;
        }
        for (float timer = 0; timer < timerDuration; timer += Time.deltaTime*3)
        {
            float progress = timer / timerDuration;
            totalScore = (int)Mathf.Lerp(start, newScore, progress);
            totalScoreText.text = $"Total Score: {totalScore}";
            yield return null;
        }
        totalScore = newScore;
        totalScoreText.text = $"Total Score: {totalScore}";
        counting = false;
    }

    public IEnumerator CountUpHigh(float newScore)
    {
        float start = highScore;
        for (float timer = 0; timer < timerDuration; timer += Time.deltaTime*3)
        {
            float progress = timer / timerDuration;
            highScore = (int)Mathf.Lerp(start, newScore, progress);
            highScoreText.text = $"High Score: {highScore}";
            yield return null;
        }
        highScore = newScore;
        highScoreText.text = $"High Score: {highScore}";
        counting = false;
    }
}
