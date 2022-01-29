using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    Transform target;    
    NavMeshAgent agent;

    public float speed = 1f;

    private BoxCollider2D triggerZone;
    public Vector3 startingPoint;   
    

    // Start is called before the first frame update
    void Start()
    {        
        target = PlayerController.pm.player.transform;
        startingPoint = transform.position;
        triggerZone = GetComponent<BoxCollider2D>();


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            agent.SetDestination(target.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            agent.SetDestination(startingPoint);
        }
    }
}
