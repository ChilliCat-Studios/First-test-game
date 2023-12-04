using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering; //Katz :)


public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool mouse_over = false;

    

    public void OnPointerEnter (PointerEventData eventData)
    {
        mouse_over = true;
        UImanager.main.SetHoveringState (true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        UImanager.main.SetHoveringState(false);
    }
}
