using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDoor : MonoBehaviour
{
    Animator myAnim;

    public bool doorState = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor(bool state)
    {
        if (!state)
        {
            if (!doorState)
            {
                return;
            }
            else
            {
                doorState = !doorState;
                myAnim.SetBool("Open", doorState);
            }
        }
        else
        {
            if (!doorState)
            {
                doorState = !doorState;
                myAnim.SetBool("Open", doorState);
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ToggleDoor(false);
        }
    }

}
