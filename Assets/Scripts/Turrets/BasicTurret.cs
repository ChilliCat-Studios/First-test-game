using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class BasicTurret : TargetingTurret
{
    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;

    private int lvl = 1;
    BasicTurret BasTurret;

    private void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeBasicTurret);
    }


    public override void Attack()
    {
        if (target == null) return;
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        UImanager.main.SetHoveringState(false);
    }

    public void UpgradeBasicTurret()
    {
        if(BaseUpgradeCost > LevelManager.main.currency) return;

        LevelManager.main.SpendCurrency(BaseUpgradeCost);
        
        targetingRange++;
        attackSpeed++;
        lvl++;

        CloseUpgradeUI();

        Debug.Log("New TargetInRange: "+ targetingRange);
        Debug.Log("New level: "+ lvl);
        Debug.Log("New atck: " + attackSpeed);
        //CloseUpgradeUI();


    }
}