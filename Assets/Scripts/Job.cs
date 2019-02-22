using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job
{
    public enum JobType
    {
        Unemployed,
        Farmer
    }
    [SerializeField]
    private JobType m_Type;
    public JobType Type { get { return m_Type; } protected set { m_Type = value; } }

    [SerializeField]
    private List<Task> m_Tasks = new List<Task>();
    public IEnumerable<Task> Tasks { get { return m_Tasks.AsReadOnly(); } }

    public Job(JobType type)
    {
        Type = type;
    }
}
