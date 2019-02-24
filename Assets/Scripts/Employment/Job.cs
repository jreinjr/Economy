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

    [SerializeField]
    private Employer m_Employer;
    public Employer Employer { get { return m_Employer; } internal set { m_Employer = value; } }

    public Job(JobDescription d, Employer e, Transform t)
    {
        m_Employer = e;
        description = d;
        transform = t;
    }
}

