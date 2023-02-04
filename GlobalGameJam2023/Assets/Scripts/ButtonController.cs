using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator tipsAnimator;
    [SerializeField] private GameObject choiceCanvas;

    public void ClosePapper()
    {
        EventManager.OnTransitionEnd.Invoke();
        Debug.Log("SELAMUN ALEYKUM");

        tipsAnimator.SetBool("ClosePapper",true);
        tipsAnimator.SetBool("OpenPapper", false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Choice1()
    {
        EventManager.OnTransitionEnd.Invoke();

        Cursor.lockState = CursorLockMode.Locked;

        choiceCanvas.SetActive(false);
    }
    public void Choice2()
    {
        EventManager.OnTransitionEnd.Invoke();

        Cursor.lockState = CursorLockMode.Locked;

        choiceCanvas.SetActive(false);
    }
}
