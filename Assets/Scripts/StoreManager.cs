using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    //may not be needed
    [Header("references")]
    [SerializeField]
    private GameObject defaultBtn;

    public static StoreManager main;
    private GameObject selectedBtn;

    private void Start()
    {
        main = this;
        defaultBtn.GetComponent<Button>().interactable = false;
        selectedBtn = defaultBtn;
    }

    public void UpdateSelectedItem(GameObject btn, GameObject SelectItemPrefab)
    {
        Debug.Log(btn + " " + SelectItemPrefab);
        this.selectedBtn.GetComponent<Button>().interactable = true;
        this.selectedBtn = btn;
        this.selectedBtn.GetComponent<Button>().interactable = false;

        BuildManager.main.SetSelectedTower(SelectItemPrefab);
    }
}
