using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotion : MonoBehaviour
{
    private bool potionsLeft = true;
    Animator animator;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            if (potionsLeft)
                Heal();
            else
                Debug.Log("You don't have any healing potion left!");
    }

    void Heal()
    {
        if (player.currentHealth != player.maxHealth)
        {
            if (player.currentHealth <= player.maxHealth - 4)
                player.currentHealth += 4;
            else
                player.currentHealth = player.maxHealth;
            potionsLeft = false;
            animator.SetTrigger("PotionUsed");
        }
        else Debug.Log("Can't heal with full health!");
    }
}
