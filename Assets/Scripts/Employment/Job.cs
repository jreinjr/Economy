using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job
{
    [Expandable]
    public JobDescription description;
    public Transform transform;
    public Inventory fromInventory;
    public Inventory toInventory;

    public Job(JobDescription d, Transform t)
    {
        description = d;
        transform = t;
    }
}

