using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : EnemyMovement
{
    [Header("Enemy DMG Settings")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float pushForce = 2f;
    [SerializeField] private float cooldown = 0.3f;
    [SerializeField] private float lastSwing;
    [SerializeField] public float attackRange;
    [Header("Enemy Loot Settings")]
    [SerializeField] GameObject[] drop;

    private bool facingRight = false;
    private Animator animator;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }
    private void MoveEnemy()
    {
        if (pushedForce > 0)
        {
            agent.speed = speed - pushedForce;
            pushedForce -= pushRecoverySpeed;
        }
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            rb.velocity = agent.desiredVelocity;
        }
        else
            rb.velocity = Vector3.zero;
    }
    public void SpeedReverse(int x)
    {
        speed = x;
    }
    public override void Die()
    {
        GameManager.instance.livingEnemies.Remove(gameObject);
        GameManager.instance.EnemyDown();
        Drop();
        base.Die();
    }
    //drop itemka
    private void Drop()
    {
        int chance = Random.Range(1, 5);
        if (chance == 1)
            Instantiate(drop[1], transform.position, transform.rotation);
        if (chance == 2)
            Instantiate(drop[2], transform.position, transform.rotation);
        if (chance > 2)
            Instantiate(drop[0], transform.position, transform.rotation);
    }

    private void Flip()
    {
        //prosta zamiana wartoœci boola na przeciwn¹
        facingRight = !facingRight;
        // zmiana skali z 1 na -1 lub z -1 na 1 :)
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
