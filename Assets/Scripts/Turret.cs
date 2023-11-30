using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Turret : MonoBehaviour
{

    [Header("References")]
    [SerializeField]
    private Transform turretRotationPoint;
    [SerializeField]
    private LayerMask enemyMask;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firingPoint;


    [Header("Attribute")]
    [SerializeField] 
    private float targetingRange = 3f;
    [SerializeField]
    private float rotationSpeed = 300f;
    [SerializeField]
    private float bps = 1f; //bullets per second

    private Transform target;
    private float timeUntilFire;


    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (!TargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1f / bps)
            {
                ShootTarget();
                timeUntilFire = 0;
            }
        }

        if (target == null)
        {
            FindTarget();
            return;
        }

        RoatateTowardsTarget();

        
    }

    private void ShootTarget()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private bool TargetIsInRange()
    {
        return target != null && 
            Vector2.Distance(target.position,transform.position) < targetingRange;
    }

    private void RoatateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, 
            target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRoation = Quaternion.Euler(new Vector3(0,0,angle));
        turretRotationPoint.rotation = 
            Quaternion.RotateTowards(turretRotationPoint.rotation, targetRoation, rotationSpeed * Time.deltaTime);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,
            (Vector2)transform.position, 0f, enemyMask);

        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
