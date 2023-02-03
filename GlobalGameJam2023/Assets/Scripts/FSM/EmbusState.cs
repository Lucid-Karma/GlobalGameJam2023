using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbusState : PlayerStates
{
    public override void EnterState(PlayerMovement fsm)
    {
        Debug.Log("getting in the car");
    }

    public override void UpdateState(PlayerMovement fsm)
    {
        // if (fsm.executingState == ExecutingState.INIDLE)
        // {
        //     InteractWithInventory();
        // }
        // else 
        //     ExitState(fsm);
    }

    public override void ExitState(PlayerMovement fsm)
    {
        // if(fsm.executingState == ExecutingState.INRUN)
        // {
        //     fsm.SwitchState(fsm.inRunningState);
        // }
        // else if(fsm.executingState == ExecutingState.OUTRUN)
        // {
        //     fsm.SwitchState(fsm.outRunningState);
        // }
    }
}
