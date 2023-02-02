using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStates 
{
    public abstract void EnterState(PlayerFsm fsm);
    public abstract void UpdateState(PlayerFsm fsm);
    public abstract void ExitState(PlayerFsm fsm);
}