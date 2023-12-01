using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTurret : BaseTurret
{


    [SerializeField]
    private float secondsToFreeze = 1f;

    public override void Attack()
    {
        FreezeEnemies();
    }

    private void FreezeEnemies()
    {
        Debug.Log("Freeze");
        foreach (RaycastHit2D hit in hits)
        {
            EnemyMovement enemyScript = hit.transform.GetComponent<EnemyMovement>();
            enemyScript.UpdateSpeed(0.25f);
            StartCoroutine(ResetEnemySpeed(enemyScript));
        }

    }

    private IEnumerator ResetEnemySpeed(EnemyMovement enemyScrpit)
    {
        yield return new WaitForSeconds(secondsToFreeze);

        enemyScrpit.ResetMoveSpeed();
    }
}
