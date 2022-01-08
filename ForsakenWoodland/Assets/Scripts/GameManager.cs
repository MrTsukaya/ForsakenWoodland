using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int sceneIndex;

    public int gold;

    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;        
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void NextLevel()
    {        
        if (SceneManager.sceneCountInBuildSettings > sceneIndex + 1)
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void SaveState()
    {
        //zapis
    }
    public void LoadState()
    {
        //wczytanie
    }

}
