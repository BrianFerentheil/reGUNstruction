using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    ScoreManager sm;
    AudioManager am;
    public float point;
    public GameObject hitEffect;
    private Transform hitTransform;


    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        am = FindObjectOfType<AudioManager>();
        hitEffect = (GameObject)Resources.Load("Prefabs/Flash 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        sm.currentScore = sm.currentScore + point;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>() != null)
        {
            //hitTransform = other.transform;
            am.PlayAudio("Goal");
            Instantiate(hitEffect, this.transform);
        }
    }
}
