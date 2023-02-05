using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnInventoryInteract = new UnityEvent();

    public static UnityEvent OnTransitionStart = new UnityEvent();  // Every kind of circumstances to NOT move and zero mouse movement.
    public static UnityEvent OnTransitionEnd = new UnityEvent();
    public static UnityEvent OnOpenPapper = new UnityEvent();   // Used for Dialogue System. -No player movement, but mouse movement is ok-
    public static UnityEvent OnClosePapper = new UnityEvent();

    public static UnityEvent OnHumanTalk = new UnityEvent();
    public static UnityEvent OnFinalTalk = new UnityEvent();

}
