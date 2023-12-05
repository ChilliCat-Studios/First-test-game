using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] EnemyPrefabs; //so we can have multiple types of enemies in the future



    [Header("Attributes")]
    [SerializeField] private int BaseAmountOfEnemies = 2;
    [SerializeField] private float EnemiesPerSecond = 0.5f;
    [SerializeField] private float TimeOutPerWave = 1f;
    [SerializeField] private float DifficultyLevelIncrease = 2f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();


    private int CurrentWave = 1;
    private int EnemiesAlive;
    private float TimeSinceLastSpawn;
    private int EnemiesLeftToSpawn;
    private bool AreEnemiesSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDead);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!AreEnemiesSpawning) return;

        TimeSinceLastSpawn += Time.deltaTime;

        if (TimeSinceLastSpawn >= (1f / EnemiesPerSecond) && EnemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            EnemiesLeftToSpawn--;
            EnemiesAlive++;
            TimeSinceLastSpawn = 0f;
        }

        if (EnemiesAlive == 0 && EnemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }
    private void SpawnEnemy()
    {
        int index = Random.Range(0, EnemyPrefabs.Length);
        GameObject PrefabToSpawn = EnemyPrefabs[index];
        Instantiate(PrefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        Debug.Log("Sapwn Enemy");
    }

    private void EnemyDead()
    {
        EnemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(TimeOutPerWave);
        AreEnemiesSpawning = true;
        EnemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        AreEnemiesSpawning = false;
        TimeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
        CurrentWave++;
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(BaseAmountOfEnemies * (Mathf.Pow(CurrentWave, DifficultyLevelIncrease)));
    }

}
