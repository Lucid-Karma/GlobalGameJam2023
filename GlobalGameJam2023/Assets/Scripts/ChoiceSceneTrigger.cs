using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSceneTrigger : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] private GameObject choiceCanvas;
    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        choiceCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            choiceCanvas.SetActive(true);

            EventManager.OnTransitionStart.Invoke();

            Cursor.lockState = CursorLockMode.None;

            gameObject.SetActive(false);
        }
    }
}
