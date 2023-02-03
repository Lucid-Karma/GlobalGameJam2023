using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : PlayerStates
{
    public override void EnterState(PlayerMovement fsm)
    {
        Debug.Log("walking");
    }

    public override void UpdateState(PlayerMovement fsm)
    {
        if (fsm.executingState == ExecutingState.WANDER)
        {
            fsm.Move();
        }
        else 
            ExitState(fsm);
    }

    public override void ExitState(PlayerMovement fsm)
    {
        if(fsm.executingState == ExecutingState.EMBUS)
        {
            fsm.SwitchState(fsm.embusState);
        }
        // else if(fsm.executingState == ExecutingState.OUTRUN)
        // {
        //     fsm.SwitchState(fsm.outRunningState);
        // }
    }
}
