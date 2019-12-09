using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class IceFloor : MonoBehaviour
{
    float meltTimer = 0.0f;
    float meltTime = 5.0f;
    [SerializeField] bool Tester = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Tester)
        {
            meltTimer += Time.deltaTime;
            if (meltTimer >= meltTime)
            {

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Hack Work
            //other.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed *= 2.0f;
            //other.gameObject.GetComponent<FirstPersonController>().m_RunSpeed *= 2.0f;
            other.gameObject.GetComponent<FirstPersonController>().Accelerate();
            Debug.Log("Accelerating");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Smooth deceleration
            // Hack Work
            //other.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed *= .5f;
            //other.gameObject.GetComponent<FirstPersonController>().m_RunSpeed *= .5f;
            other.gameObject.GetComponent<FirstPersonController>().Decelerate();
            Debug.Log("Decelerating");
        }
    }

}
