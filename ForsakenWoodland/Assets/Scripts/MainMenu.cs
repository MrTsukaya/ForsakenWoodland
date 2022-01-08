using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
    }

    public void SaveGame()
    {
        GameManager.instance.SaveState();
    }

    public void LoadGame()
    {
        GameManager.instance.LoadState();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
