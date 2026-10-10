using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        // Modifica o estado global do mundo incrementando 1 paciente à espera
        GWorld.Instance.GetWorld().ModifyState("Waiting", 1);
        return true;
    }
}