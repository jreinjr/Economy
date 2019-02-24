using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Option
{
    [SerializeField]
    private string m_Description;
    public string Description { get { return m_Description; } protected set { m_Description = value; } }

    // From 0-1
    public abstract float GetWeight();
}

public class ResourceInInventoryOption : Option
{
    public ResourceInInventoryGoal Goal;

    public override float GetWeight()
    {
        return 0.5f;
    }
}