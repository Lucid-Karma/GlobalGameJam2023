using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStates 
{
    public abstract void EnterState(PlayerMovement fsm);
    public abstract void UpdateState(PlayerMovement fsm);
    public abstract void ExitState(PlayerMovement fsm);
}