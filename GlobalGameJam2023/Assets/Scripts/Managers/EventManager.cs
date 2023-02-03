using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnInventoryInteract = new UnityEvent();

    public static UnityEvent OnTransitionStart = new UnityEvent();
    public static UnityEvent OnTransitionEnd = new UnityEvent();
}
