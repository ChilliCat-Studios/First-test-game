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
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,
            (Vector2)transform.position, 0f, enemyMask);

        if(hits.Length > 0 )
        {
            foreach(RaycastHit2D hit in hits) { 
                EnemyMovement enemyScript = hit.transform.GetComponent<EnemyMovement>();
                enemyScript.UpdateSpeed(0.25f);
                StartCoroutine(ResetEnemySpeed(enemyScript));
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement enemyScrpit)
    {
        yield return new WaitForSeconds(secondsToFreeze);

        enemyScrpit.ResetMoveSpeed();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
