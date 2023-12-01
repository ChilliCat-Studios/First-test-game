using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    //may not be needed
    [Header("references")]
    [SerializeField]
    private GameObject defaultItem;

    private GameObject selectedItem;

    private void Start()
    {
        defaultItem.GetComponent<Button>().interactable = false;
        selectedItem = defaultItem;
    }

    public void UpdateSelectedItem(GameObject selectedItem)
    {
        this.selectedItem.GetComponent<Button>().interactable = true;
        this.selectedItem = selectedItem;
        this.selectedItem.GetComponent<Button>().interactable = false;
    }
}
