using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class BasicTurret : TargetingTurret
{
    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firingPoint;


    public override void Attack()
    {
        if (target == null) return;
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
}