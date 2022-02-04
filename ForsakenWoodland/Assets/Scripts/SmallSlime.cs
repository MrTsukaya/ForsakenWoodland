using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallSlime : MonoBehaviour
{
    [Header("Slime Movement Settings")]
    [SerializeField] protected float speed;
    NavMeshAgent agent;
    private Vector3 start;
    private Vector3 roam;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;

        start = transform.position;        
        InvokeRepeating("SetNewPath", 1f, Random.Range(1f, 2f));
    }

    void SetNewPath()
    {
        roam = RandomDir();
        agent.SetDestination(roam);
    }
    private Vector3 RoamingPosition()
    {
        return start + RandomDir() * Random.Range(5f, 15f);
    }
    private static Vector3 RandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
