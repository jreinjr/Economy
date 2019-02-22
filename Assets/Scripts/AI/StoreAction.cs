using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Store Action")]
public class StoreAction : Action
{
    public override void Act(StateController controller)
    {
        Store(controller);
    }

    private void Store(StateController controller)
    {
        throw new System.NotImplementedException();
    }
}
