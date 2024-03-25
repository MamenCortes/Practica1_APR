using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_FollowPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (GameManager.Instance.alive)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true; 
        }
        
    }
}