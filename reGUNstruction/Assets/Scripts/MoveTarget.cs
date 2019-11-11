using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;
    int currentWaypoint = 0;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Vector3.Distance(transform.position, wayPoints[currentWaypoint].position) < .25f)
        {
            currentWaypoint += 1;
            currentWaypoint = currentWaypoint % wayPoints.Length;
        }
        Vector3 _dir = (wayPoints[currentWaypoint].position - transform.position).normalized;
        rb.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
    }
}
