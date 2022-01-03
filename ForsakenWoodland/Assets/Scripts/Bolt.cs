using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int boltDamage = 20;
    private Rigidbody2D bulletRig;
   

    void Start()
    {
        bulletRig = GetComponent<Rigidbody2D>();
        bulletRig.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SampleEnemy enemy = collision.GetComponent<SampleEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(boltDamage);
        }
        if (!collision.CompareTag("Player"))
            Destroy(gameObject);
    }
    
    
    void OnBecameInvisible()
    {
        Destroy(gameObject, 1);
    }
}
