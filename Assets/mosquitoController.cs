using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mosquitoController : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private NavMeshAgent agent;

    public float radius;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!agent.hasPath)
        {
            agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, radius));
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, radius);
    }

#endif
}