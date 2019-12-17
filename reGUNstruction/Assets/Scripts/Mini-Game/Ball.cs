using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    AudioManager am;
    MinigameWall[] walls;
    BasketMinigameWall[] basketWalls;
    public bool basketball;
    public bool soccerball;

    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        walls = FindObjectsOfType(typeof(MinigameWall)) as MinigameWall[];
        basketWalls = FindObjectsOfType(typeof(BasketMinigameWall)) as BasketMinigameWall[];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Goal>() != null)
        {
            other.GetComponent<Goal>().Score();
            Destroy(gameObject,0.2f);
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(basketball)
        {
            foreach(BasketMinigameWall wall in basketWalls)
            {
                if (wall.playerEnter)
                {
                    am.PlayAudio("BallBounce");
                }
                if(!wall.playerEnter)
                {
                    return;
                }
            }
        }

        if (soccerball)
        {
            foreach (MinigameWall wall in walls)
            {
                if (wall.playerEnter)
                {
                    am.PlayAudio("BallBounce");
                }
                if(!wall.playerEnter)
                {
                    return;
                }
            }
        }
        
    }
}
