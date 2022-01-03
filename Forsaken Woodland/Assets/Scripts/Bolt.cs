using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int boltDamage = 20;
    private Rigidbody bulletRig;
   

    void Start()
    {
        bulletRig = GetComponent<Rigidbody>();
        bulletRig.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        SampleEnemy enemy = other.GetComponent<SampleEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(boltDamage);
        }
        if(!other.CompareTag("Player"))
            Destroy(gameObject);
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject, 1);
    }
}
