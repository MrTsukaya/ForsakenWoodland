using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : Killable
{
    [Header("Enemy Movement Settings")]
    [SerializeField] protected float speed;
    protected Transform target;
    protected NavMeshAgent agent;
   
    // Start is called before the first frame update

    protected override void Start()
    {
        base.Start();
        target = PlayerController.pm.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void UpdatePath()
    {
        if (target != null)
            agent.SetDestination(target.position);
        Debug.Log(agent.destination);
    }
}
