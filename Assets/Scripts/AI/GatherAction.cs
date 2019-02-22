using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Gather Action")]
public class GatherAction : Action
{
    public override void Act(StateController controller)
    {
        Gather(controller);
    }

    private void Gather(StateController controller)
    {
        throw new System.NotImplementedException();
    }
}
