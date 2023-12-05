using System.Collections;
using System.Collections.Generic;
using UnityEngine; //Katz :)

public class UImanager : MonoBehaviour
{
    public static UImanager main;

    private bool isHoveringUI;

    private void Awake()
    {
        main = this;
    }

    public void SetHoveringState(bool state)
    {
        isHoveringUI = state;
    }

    public bool IsHoveringUI()
    {
        return isHoveringUI;
    }
}
