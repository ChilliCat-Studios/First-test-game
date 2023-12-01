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

    protected Transform target;
    private float timeUntilFire;


    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        timeUntilFire += Time.deltaTime;

        
        if (timeUntilFire >= 1f / attackSpeed)
        {
            Attack();
            timeUntilFire = 0;
        }

    }

    public abstract void Attack();
}

