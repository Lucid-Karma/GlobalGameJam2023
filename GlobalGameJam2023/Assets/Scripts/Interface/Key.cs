using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public bool hasKey = false;

    public void Meet()
    {
        hasKey = false;
        //EventManager.OnInventoryInteract.Invoke();
    }
    public void Interact()
    {
        hasKey = true;
        gameObject.SetActive(false);
    }
}
