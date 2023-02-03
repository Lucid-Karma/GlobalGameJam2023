using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ClosePapper()
    {
        EventManager.OnClosePapper.Invoke();
        Debug.Log("SELAMUN ALEYKUM");

        animator.SetBool("ClosePapper",true);
        animator.SetBool("OpenPapper", false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
