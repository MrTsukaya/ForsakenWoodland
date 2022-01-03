using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    [Header("Ustawienia przeciwnika")]
    [SerializeField] private int health = 100;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }

}
