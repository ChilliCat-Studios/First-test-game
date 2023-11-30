using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField]
    private int hp = 2;

    private bool isDestroyed = false;
    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

}
