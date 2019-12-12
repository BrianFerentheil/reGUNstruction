using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBenchInteract : MonoBehaviour
{
    public bool playerClose = false;
    public bool inBench = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClose && !inBench)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inBench = true;
                TheMachine.stateMachine.ChangeState(new GunBuildingMenu());
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "FPSController")
        {
            playerClose = false;
        }
    }
}
