using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    public void Meet()
    {
    }
    public void Interact()
    {
        EventManager.OnOpenPapper.Invoke();

        animator.SetBool("OpenPapper",true);
        animator.SetBool("ClosePapper", false);

        Cursor.lockState = CursorLockMode.None;
    }
}
