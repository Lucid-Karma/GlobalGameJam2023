using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoZone : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("OpenInfo", true);
            animator.SetBool("CloseInfo", false);
        }   
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("OpenInfo", false);
            animator.SetBool("CloseInfo", false);
        } 
    }
}
