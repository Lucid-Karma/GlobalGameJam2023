using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbusState : PlayerStates
{
    public override void EnterState(PlayerMovement fsm)
    {
        Debug.Log("stopped");
    }

    public override void UpdateState(PlayerMovement fsm)
    {
        if (fsm.executingState == ExecutingState.EMBUS)
        {
            
        }
        else 
            ExitState(fsm);
    }

    public override void ExitState(PlayerMovement fsm)
    {
        if(fsm.executingState == ExecutingState.WANDER)
        {
            fsm.SwitchState(fsm.wanderState);
        }
        // else if(fsm.executingState == ExecutingState.OUTRUN)
        // {
        //     fsm.SwitchState(fsm.outRunningState);
        // }
    }
}
