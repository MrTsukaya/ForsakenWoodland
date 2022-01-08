using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject escMenu;
    public bool isPaused;

    void Start()
    {
        isPaused = false;
        escMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Update dziala");
            pauseGame();
        }
    }

    void pauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            escMenu.SetActive(true);
            Debug.Log("Funckja dziala");
        }
        else
        {
            Time.timeScale = 1;
            escMenu.SetActive(false);
        }
        isPaused = !isPaused;
    }
}
