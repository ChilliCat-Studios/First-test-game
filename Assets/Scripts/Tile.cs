using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Color hoverColor;


    private GameObject towerObj;
    private Color startColor;
    public BasicTurret turret1;


    private void Start()
    {
        startColor = sr.color;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if(UImanager.main.IsHoveringUI()) return; //Katz :)


        //prevent clicking tiles behind ui
        if (EventSystem.current.IsPointerOverGameObject()) return;

        //in the futrue replacew wiht upgrade logic and sell logic
        if (towerObj != null)
        {
            turret1.OpenUpgradeUI();
            return;
        }
        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.currency) {
            //you cant afford this tower
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);
        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        turret1 = towerObj.GetComponent<BasicTurret>();
    }
}
