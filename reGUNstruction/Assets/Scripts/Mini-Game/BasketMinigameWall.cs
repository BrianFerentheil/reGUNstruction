using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMinigameWall : MonoBehaviour
{
    public GameObject player;
    public bool playerEnter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerEnter = !playerEnter;
        }
    }
}
