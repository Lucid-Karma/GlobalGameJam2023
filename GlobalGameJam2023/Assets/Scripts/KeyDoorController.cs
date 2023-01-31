using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private bool doorOpen = false;

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;
        [SerializeField] private GameObject doorObject;

        [SerializeField] private KeyInventory _keyInventory = null;

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
            if (_keyInventory.hasRedKey)
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

    }
}
