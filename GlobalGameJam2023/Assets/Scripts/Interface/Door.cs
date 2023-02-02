using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, IInteractable
{
    private bool doorOpen = false;
    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;
    [SerializeField] private GameObject doorObject;

    [SerializeField] private Key key = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    [SerializeField] private GameObject futureDoor;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }
    public void PlayDoTween()
    {
        if (key.hasKey)
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorObject.transform.DORotate(doorObject.transform.eulerAngles + new Vector3(0, -90, 0), 1.5f).SetEase(Ease.InOutCubic)
                .OnStart(() =>
                {
                    // isDoor = true;
                })
                .OnComplete(() =>
                {
                    // isDoor = false;
                });
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }
            else if (doorOpen && !pauseInteraction)
            {
                doorObject.transform.DORotate(doorObject.transform.eulerAngles + new Vector3(0, 90, 0), 1.5f).SetEase(Ease.InOutCubic)
                .OnStart(() =>
                {
                    // isDoor = true;
                })
                .OnComplete(() =>
                {
                    // isDoor = false;
                });
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }
        else
        {
            StartCoroutine(ShowDoorLocked());
        }
    }
    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }

    public void Meet()
    {
        //EventManager.OnInventoryInteract.Invoke();
    }
    public void Interact()
    {
        PlayDoTween();

        if (key.hasKey)
        {
            var interactable = futureDoor.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}
