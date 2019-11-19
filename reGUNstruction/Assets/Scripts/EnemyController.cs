using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject _ragdoll;
    [SerializeField] private GameObject _animatedModel;
    [SerializeField] private NavMeshAgent _navmeshAgent;

    private bool _dead;

    private void Awake()
    {
        _ragdoll.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            die();
        }
    }

    [ContextMenu("ToggleDead")]
    public void die()
    {
        if (!_dead)
        {
            _dead = true; ;

            CopyTransformData(_animatedModel.transform, _ragdoll.transform, _navmeshAgent.velocity);
            _ragdoll.gameObject.SetActive(true);
            _animatedModel.gameObject.SetActive(false);
            _navmeshAgent.enabled = false;
        }
    }

    private void CopyTransformData(Transform sourceTransform, Transform destinationTransform, Vector3 velocity)
    {
        if (sourceTransform.childCount != destinationTransform.childCount)
        {
            Debug.LogWarning("Invalid transform copy, they need to match transform hierarchies");
            return;
        }

        for (int i = 0; i < sourceTransform.childCount; i++)
        {
            var source = sourceTransform.GetChild(i);
            var destination = destinationTransform.GetChild(i);
            destination.position = source.position;
            destination.rotation = source.rotation;
            var rb = destination.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = velocity;

            CopyTransformData(source, destination, velocity);
        }
    }
}
