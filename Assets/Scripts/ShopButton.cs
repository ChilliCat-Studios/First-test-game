using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject turret;

    public void updateShopItem(GameObject btn)
    {
        StoreManager.main.UpdateSelectedItem(btn, turret);
    }
}
