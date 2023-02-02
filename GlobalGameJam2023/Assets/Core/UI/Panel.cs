using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private Image crosshair = null;
    [SerializeField] private GameObject pressEUI;

    void OnEnable()
    {
        EventManager.OnInventoryInteract.AddListener(ShowText);
    }
    void OnDisable()
    {
        EventManager.OnInventoryInteract.RemoveListener(ShowText);
    }

    public virtual void ShowText()
    {
        pressEUI.SetActive(true);
    }

    public virtual void HideText()
    {
        pressEUI.SetActive(false);
    }
}
