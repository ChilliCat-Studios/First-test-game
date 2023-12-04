using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using NaughtyAttributes;

public abstract class BaseTurret : MonoBehaviour
{

    [Header("References")]
    [Foldout("Base")]
    [SerializeField]
    protected LayerMask enemyMask;


    [Header("Attribute")]
    [Foldout("Base")]
    [SerializeField]
    protected float targetingRange = 3f;
    [Foldout("Base")]
    [SerializeField]
    private float attackSpeed = 1f; //attacks per second

    private float timeUntilFire;

    protected RaycastHit2D[] hits;

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    public virtual void Update()
    {
        timeUntilFire += Time.deltaTime;

        //calc towers in range
        hits = Physics2D.CircleCastAll(transform.position, targetingRange,
            (Vector2)transform.position, 0f, enemyMask);

        if (timeUntilFire >= 1f / attackSpeed && hits.Length > 0)
        {
            Attack();
            timeUntilFire = 0;
        }

    }

   
    public abstract void Attack();
}

