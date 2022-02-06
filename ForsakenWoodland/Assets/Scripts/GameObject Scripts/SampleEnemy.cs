using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : EnemyMovement
{      
    // po co to ?
    [Header("Enemy DMG Settings")]
    public GameObject sampleEnemy;
    public int position;
    [Header("Enemy DMG Settings")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float pushForce = 2f;   
    [SerializeField] private float cooldown = 0.3f;
    [SerializeField] private float lastSwing;
    [Header("Enemy Loot Settings")]
    [SerializeField] GameObject drop;

    private void FixedUpdate()
    {
        MoveEnemy();          
    }
    private void MoveEnemy()
    {
        if(pushedForce > 0)
        {
            agent.speed = speed - pushedForce;
            pushedForce -= pushRecoverySpeed;
        }
        if (agent.remainingDistance > agent.stoppingDistance)
        {            
            rb.velocity = agent.desiredVelocity;
        }            
        else
            rb.velocity = Vector3.zero;
    }    
    //na kolizji sprawdza czy gracz, jak tak to mu bije
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Damage dmg = new Damage(transform.position, damage, pushForce);
                collision.collider.SendMessage("TakeDamage", dmg);
            }
        }
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
        int chance = Random.Range(1, 4);        
        if(chance == 3)
        {
            Instantiate(drop, transform.position, transform.rotation);
        }
        
    }

}
