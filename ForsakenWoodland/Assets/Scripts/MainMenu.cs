using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
