using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    

    void Start()
    {
        
    }

    

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Goal>() != null)
        {
            other.GetComponent<Goal>().Score();
            Destroy(gameObject,0.1f);
        }
        else
        {
            return;
        }
    }
}
