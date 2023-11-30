using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Color hoverColor;


    private GameObject tower;
    private Color startColor;


    private void Start()
    {
        startColor = sr.color;
    }


    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        //in the futrue replacew wiht upgrade logic and sell logic
        if (tower != null) return;


        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

    }
}
