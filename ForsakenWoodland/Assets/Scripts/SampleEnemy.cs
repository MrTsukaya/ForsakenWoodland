using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    [Header("Ustawienia przeciwnika")]
    [SerializeField] private int health = 100;
    [SerializeField] GameObject drop;



    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Drop();
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void Drop()
    {
        int chance = Random.Range(1, 4);
        Debug.Log(chance);
        if(chance == 3)
        {
            Instantiate(drop, transform.position, transform.rotation);
        }
        
    }

}
