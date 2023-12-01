using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TextMeshProUGUI currencyUI;
    [SerializeField]
    Animator anim;

    private bool isOpen = true;

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        anim.SetBool("MenuOpen", isOpen);
    }

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }
}
