using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject player;
    public GameObject enemy;
    public float radius;
    float distance;
    public float speed = 10;

    private void Start()
    {
        distance = Vector3.Distance(player.transform.position, enemy.transform.position);
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (distance < 20)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (!agent.hasPath)
            {
                agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, radius));
            }
        }

    }

#if UNITY_EDITOR

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, radius);
    }

#endif
}