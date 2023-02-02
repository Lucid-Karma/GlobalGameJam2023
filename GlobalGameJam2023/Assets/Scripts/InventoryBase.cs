using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryBase : MonoBehaviour, IInteractable
{
    [SerializeField] private Image crosshair = null;
    [SerializeField] private GameObject pressEUI;
    private bool isCrosshairActive, doOnce;
    public bool hasKey = false;


    public void Meet()
    {
        hasKey = false;
    }
    public abstract void Interact();

    

    void SetCrosshair()
    {
        if (!doOnce)
        {
            CrosshairChange(true);
        }

        isCrosshairActive = true;
        doOnce = true;
    }
    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
