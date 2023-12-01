using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Unity.VisualScripting;
using NaughtyAttributes;

public abstract class TargetingTurret : BaseTurret
{
    [Header("References")]
    [Foldout("Targeting")]
    [SerializeField]
    private Transform turretRotationPoint;

    [Header("Attributes")]
    [Foldout("Targeting")]
    [SerializeField]
    private float rotationSpeed = 300f;
    



    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    public override void Update()
    {
        if (!TargetIsInRange())
        {
            target = null;
        }

        base.Update();



        if (target == null)
        {
            FindTarget();
            return;
        }
        RoatateTowardsTarget();
    }

    private void RoatateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, 
            target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRoation = Quaternion.Euler(new Vector3(0,0,angle));
        turretRotationPoint.rotation = 
            Quaternion.RotateTowards(turretRotationPoint.rotation, targetRoation, rotationSpeed * Time.deltaTime);
    }

    private bool TargetIsInRange()
    {
        return target != null &&
            Vector2.Distance(target.position, transform.position) < targetingRange;
    }

    //rework to have targeting priority IE furthest enemy
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,
            (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
