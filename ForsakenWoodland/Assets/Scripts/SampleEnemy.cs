using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : Killable
{
    
    // po co to ?
    public GameObject sampleEnemy;
    public int position;
    [Header("Enemy DMG Settings")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float pushForce = 2f;   
    [SerializeField] private float attackDelay = 3;
    [Header("Enemy Loot Settings")]
    [SerializeField] GameObject drop;

    private bool attacked = false;

    //na kolizji sprawdza czy gracz, jak tak to mu bije
    private void OnCollisionStay2D(Collision2D collision)
    {      
        if (collision.collider.CompareTag("Player"))
        {
            if(!attacked)
            {
                Damage dmg = new Damage(transform.position, damage, pushForce);
                collision.collider.SendMessage("TakeDamage", dmg);
                //daje delay ¿eby gracz nie gin¹³ w sekundê XD
                attacked = true;
                attackDelay = 3;
            }
            
        }
    }
    private void Update()
    {
        //je¿eli attacked = true to odejmuje czas potrzebny na generowanie klatki, jak spadnie poni¿ej
        //to oddaje mo¿liwoœæ atatku
        if (attacked)
        {
            attackDelay -= Time.deltaTime;   
            if(attackDelay <= 0)
            {
                attacked = false;               
            }
        }        
    }
    protected override void Die()
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
