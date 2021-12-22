using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent m_navMeshAgent;
    GameObject m_player;

    void Start ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update ()
    {
        m_navMeshAgent.isStopped = false;
        m_navMeshAgent.SetDestination(m_player.transform.position);
    }
}
