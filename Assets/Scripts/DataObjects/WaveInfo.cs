using UnityEngine;
using System;
using UnityEditor;

[Serializable]
public class WaveInfo
{
    public GUID guid;
    public GameObject prefab;
    public int numEnemies;
    public int waveOrderNumber;
    public int timeToNextWavePart;
    public float enemiesPerSecond;

    public float getEnemySpawnRate()
    {
        return 1f / enemiesPerSecond;
    }
}
