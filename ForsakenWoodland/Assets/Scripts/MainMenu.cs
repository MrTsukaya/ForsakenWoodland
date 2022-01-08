using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play dzia�a");
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGame()
    {
        Debug.Log("Load dzia�a");
        GameManager.instance.LoadState();
    }

    public void ExitGame()
    {
        Debug.Log("Exit dzia�a");
        Application.Quit();
    }
}
