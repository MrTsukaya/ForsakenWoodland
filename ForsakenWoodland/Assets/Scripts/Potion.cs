using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public PlayerController player;

    // Leczenie jak nacisnie Q (todo ekwipunek i ilosc potek pozniej)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Heal();
    }

    //Leczonko z umiarem
    void Heal()
    {
        if (player.currentHealth <= player.maxHealth - 2) player.currentHealth += 2;
        else if (player.currentHealth == player.maxHealth - 1) player.currentHealth++;
        else Debug.Log("Can't heal with full health!"); 
    }
}
