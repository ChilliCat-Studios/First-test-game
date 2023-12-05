using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Wave[] waves;



    [Header("Attributes")]
    [SerializeField] private float timeBetweenWaves = 5f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();


    private Dictionary<GUID, float> infoGuidToTimeSinceLastSpawn = new Dictionary<GUID, float>();
    private int enemiesAlive;
    private bool isSpawning = false;

    private int currentWaveIndex = 0;
    private Wave currentWave;
    private WaveInfo[] currentWaveInfo;
    private int currentWaveInfoNumber;

    private float waveTimer = 0;


    #region unity methods

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        currentWave = waves.First(wave => wave.waveIndex == currentWaveIndex);
        currentWaveInfoNumber = 0;
        currentWaveInfo = currentWave.waveInfo.Where(info => info.waveOrderNumber == currentWaveInfoNumber).ToArray();
        BuildNewTimeMap();
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if(!isSpawning) return;

        foreach(WaveInfo info in currentWaveInfo)
        {
            if(info.numEnemies > 0)
            {
                infoGuidToTimeSinceLastSpawn[info.guid] += Time.deltaTime;
                if(infoGuidToTimeSinceLastSpawn[info.guid] >= info.getEnemySpawnRate())
                {
                    SpawnEnemy(info);
                    infoGuidToTimeSinceLastSpawn[info.guid] = 0;
                }
            }
        }
        
        if(currentWaveInfo.Where(info => info.numEnemies > 0).Count() == 0)
        {
            if(IsNextWavePart())
            {
                waveTimer += Time.deltaTime;
                WaveInfo[] infoSet = currentWaveInfo.Where(info => info.timeToNextWavePart > 0).ToArray();
                if (infoSet.Length > 0 && waveTimer > infoSet[0].timeToNextWavePart)
                {
                    waveTimer = 0;
                    currentWaveInfoNumber++;
                    currentWaveInfo = currentWave.waveInfo.Where(info => info.waveOrderNumber == currentWaveInfoNumber).ToArray();
                    BuildNewTimeMap();
                }
            }
            else if (enemiesAlive == 0)
            {
                EndWave();
            }
        }
    }

    #endregion

    private bool IsNextWavePart()
    {
        WaveInfo[] newInfo = currentWave.waveInfo.Where(info => info.waveOrderNumber == currentWaveInfoNumber + 1).ToArray();
        return newInfo.Count() != 0;
    }

    private void EndWave()
    {
        isSpawning = false;
        currentWaveIndex++;
        currentWave = waves.Where(wave => wave.waveIndex == currentWaveIndex).FirstOrDefault();
        if (currentWave == null) {
            //level over, win, add logic
            return;
        }
        currentWaveInfoNumber = 0;
        currentWaveInfo = currentWave.waveInfo.Where(info => info.waveOrderNumber == currentWaveInfoNumber).ToArray();
        BuildNewTimeMap();
        StartCoroutine(StartWave());
    }

    private void BuildNewTimeMap()
    {
        infoGuidToTimeSinceLastSpawn.Clear();
        foreach(WaveInfo info in currentWaveInfo) {
            info.guid = GUID.Generate();
            infoGuidToTimeSinceLastSpawn.Add(info.guid, 0);
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private void SpawnEnemy(WaveInfo info)
    {
        Instantiate(info.prefab, LevelManager.main.startPoint.position, Quaternion.identity);
        info.numEnemies--;
        enemiesAlive++;
    }

    

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
    }

}
