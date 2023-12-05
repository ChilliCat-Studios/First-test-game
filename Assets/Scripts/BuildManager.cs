using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField]
    
    private Tower[] towers;


    private Tower selectedTower;


    private void Awake()
    {
        main = this;
        selectedTower = towers[0];
    }

    public Tower GetSelectedTower()
    {
        Debug.Log(selectedTower.name);
        return selectedTower;
    }

    public void SetSelectedTower(GameObject selectedTower)
    {
        Tower tower = towers.First(c => c.prefab.Equals(selectedTower));
        Debug.Log(tower.name);
        this.selectedTower = tower;
    }
}
