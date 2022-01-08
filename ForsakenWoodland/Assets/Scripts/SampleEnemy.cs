using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    [Header("Ustawienia przeciwnika")]
    public GameObject sampleEnemy;
    public int position;
    [SerializeField] public int health = 100;
    [SerializeField] GameObject drop;
    
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Debug.Log("Obiekt " + gameObject + " zosta³ usuniêty");
            GameManager.instance.livingEnemies.Remove(gameObject);
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
