using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class IceFloor : MonoBehaviour
{
    float meltTimer = 0.0f;
    float meltTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meltTimer += Time.deltaTime;
        if (meltTimer >= meltTime)
        {

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity *= 2.0f;
            Debug.Log("Accelerating");
        }
    }

}
