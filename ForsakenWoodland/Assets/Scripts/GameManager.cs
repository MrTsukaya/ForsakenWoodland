using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class GameManager : MonoBehaviour
{
    private int sceneIndex;

    private int enemyCount;
    private bool killedAllEnemies = false;
    public List<GameObject> livingEnemies = new List<GameObject>();

    public bool isCoinPicked = false;
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
        //dodaje do listy wszystkie obiekty z tagiem Enemy
        livingEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        //Licznik
        enemyCount = livingEnemies.Count;
        Debug.Log("Iloœæ przeciwników :" + enemyCount);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private Save CreateSave()
    {
        Save save = new Save();

        foreach (GameObject livEnemy in livingEnemies)
        {
            SampleEnemy sm = livEnemy.GetComponent<SampleEnemy>();
            if(sm.sampleEnemy != null)
            {
                save.livingEnemiesPositions.Add(sm.position);
                save.livingEnemiesHealth.Add(sm.currentHealth);
            }
        }
        save.stageIndex = sceneIndex;
        save.gold = gold;
        return save;
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
        Save save = CreateSave();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameSave.dat");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved!");
        SceneManager.LoadScene("Menu");
    }
    public void LoadState()
    {
        Debug.Log("Loading the game...");
        if(File.Exists(Application.persistentDataPath + "/gameSave.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameSave.dat", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            for(int i = 0; i < save.livingEnemiesPositions.Count; i++)
            {
                int position = save.livingEnemiesPositions[i];
                SampleEnemy sampleEnemy = livingEnemies[position].GetComponent<SampleEnemy>();
                sampleEnemy.currentHealth = save.livingEnemiesHealth[position];
            }

            gold = save.gold;
            sceneIndex = save.stageIndex;
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("Game Loaded");
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("No save file!");
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exit dzia³a");
        Application.Quit();
    }

    public void EnemyDown()
    {
        //odejmuje z licznika 
        enemyCount--;
        Debug.Log("Iloœæ przeciwników :" + enemyCount);
        if (enemyCount == 0)
        {
            killedAllEnemies = true;
            Debug.Log("Wszyscy przeciwnicy zostali zabici");

        }

    }
}
