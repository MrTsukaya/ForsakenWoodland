using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] public int currentHealth = 100;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] private float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 0.1f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    //ka¿dy kto dziedziczy t¹ klasê mo¿e otrzymaæ obra¿enia i umrzeæ
    protected virtual void TakeDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            currentHealth -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
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
