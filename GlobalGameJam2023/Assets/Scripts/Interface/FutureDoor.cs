using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FutureDoor : MonoBehaviour, IInteractable
{
    private bool doorOpen = false;


    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }
    public void PlayDoTween()
    {
        if (!doorOpen && !pauseInteraction)
        {
            gameObject.transform.DORotate(gameObject.transform.eulerAngles + new Vector3(0, -90, 0), 1.5f).SetEase(Ease.InOutCubic)
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
            gameObject.transform.DORotate(gameObject.transform.eulerAngles + new Vector3(0, 90, 0), 1.5f).SetEase(Ease.InOutCubic)
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

    public void Meet()
    {

    }
    public void Interact()
    {
        PlayDoTween();
    }
}
