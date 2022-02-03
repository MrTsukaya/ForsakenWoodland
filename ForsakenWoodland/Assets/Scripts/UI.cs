using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //Tworzymy referencje do klasy gracza; zaciagamy sprity serduszek; zaciagamy elementy UI
    public PlayerController player;
    public Sprite heartEmpty, heartHalf, heartFull;
    public GameObject[] hearts;
    
    void Start()
    {
    //Ustawiamy wartosc poczatkowa zycia gracza na maksimum
        foreach(GameObject h in hearts)
            h.transform.GetComponent<UnityEngine.UI.Image>().sprite = heartFull;
    }

    void Update()
    {
    //Co klatke sprawdzamy ilosc zycia gracza i dopasowujemy ilosc serduszek 
        if (player.currentHealth == player.maxHealth)
            foreach (GameObject h in hearts)
                h.transform.GetComponent<Image>().sprite = heartFull;
        else
        {
            foreach (GameObject h in hearts)
                h.transform.GetComponent<Image>().sprite = heartEmpty;

            for(int i = 0; i < player.currentHealth / 2; i++)
                hearts[i].transform.GetComponent<Image>().sprite = heartFull;

            if(player.currentHealth % 2 == 1)
                hearts[player.currentHealth / 2].transform.GetComponent<Image>().sprite = heartHalf;
        }
    }
}
