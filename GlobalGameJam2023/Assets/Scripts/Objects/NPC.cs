using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;

    void Awake()
    {
        uiPanel.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            uiPanel.SetActive(true);
            EventManager.OnHumanTalk.Invoke();
            EventManager.OnTransitionStart.Invoke();
        }
    }
}
