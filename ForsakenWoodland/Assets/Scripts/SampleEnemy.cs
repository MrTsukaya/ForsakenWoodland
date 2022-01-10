using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    [Header("Ustawienia przeciwnika")]
    // po co to ?
    public GameObject sampleEnemy;
    public int position;

    [SerializeField] public int health = 100;
    [SerializeField] public int damage = 20;
    [SerializeField] GameObject drop;

    [SerializeField] public float attackDelay = 3;
    private bool attacked = false;

    //na kolizji sprawdza czy gracz, jak tak to mu bije
    private void OnCollisionStay2D(Collision2D collision)
    {        
        if (collision.collider.CompareTag("Player"))
        {           
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            if (player != null && attacked == false)
            {
                player.TakeDamagePlayer(20);

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

    // funkcja otrzymywania obra¿eñ
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            //usuwa obiekt z listy GM
            GameManager.instance.livingEnemies.Remove(gameObject);
            //zmniejsza enemy counter o 1
            GameManager.instance.EnemyDown();
            Debug.Log("Obiekt " + gameObject + " zosta³ usuniêty");

            Drop();
            Die();
        }
    }
    //niszczy obiekt
    private void Die()
    {
        Destroy(gameObject);
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
