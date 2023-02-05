using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator tipsAnimator;
    [SerializeField] private GameObject choiceCanvas,choice1,choice2;

    public void ClosePapper()
    {
        EventManager.OnTransitionEnd.Invoke();
        // Debug.Log("SELAMUN ALEYKUM");

        tipsAnimator.SetBool("ClosePapper",true);
        tipsAnimator.SetBool("OpenPapper", false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Choice1()
    {
        EventManager.OnTransitionEnd.Invoke();
        

        Cursor.lockState = CursorLockMode.Locked;

        choice2.SetActive(true);
        choice1.SetActive(false);
        EventManager.OnFinalTalk.Invoke();
        
        Debug.Log("111");

        choiceCanvas.SetActive(false);
    }
    public void Choice2()
    {
        EventManager.OnTransitionEnd.Invoke();
        

        Cursor.lockState = CursorLockMode.Locked;

        choice2.SetActive(false);
        choice1.SetActive(true);
        EventManager.OnFinalTalk.Invoke();

        Debug.Log("222");

        choiceCanvas.SetActive(false);
    }
}
