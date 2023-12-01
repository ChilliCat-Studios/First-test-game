using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private int rewardAmount = 10;

    private bool isDestroyed = false;
    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            Debug.Log("increase currency about to be called with + " + rewardAmount);
            LevelManager.main.IncreaseCurrency(rewardAmount);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

}
