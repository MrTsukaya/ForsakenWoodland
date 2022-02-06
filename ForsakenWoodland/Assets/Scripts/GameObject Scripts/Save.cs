using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public List<int> livingEnemiesPositions = new List<int>();
    public List<int> livingEnemiesHealth = new List<int>();

    public int stageIndex;
    public int gold = 0;

}
