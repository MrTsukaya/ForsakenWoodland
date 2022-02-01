using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] public int currentHealth = 100;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] protected float pushRecoverySpeed = 0.2f;
    protected Rigidbody2D rb;

    protected float immuneTime = 0.1f;
    protected float lastImmune;

    protected Vector2 pushDirection;
    protected float pushedForce;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //ka¿dy kto dziedziczy t¹ klasê mo¿e otrzymaæ obra¿enia i umrzeæ
    protected virtual void TakeDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            currentHealth -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            pushedForce = dmg.pushForce;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
