using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    [SerializeField][ReadOnly]
    private Job m_Job;
    public Job Job { get { return m_Job; } internal set { m_Job = value; } }

    [SerializeField][ReadOnly]
    private Employer m_Employer;
    public Employer Employer { get { return m_Employer; } internal set { m_Employer = value; } }

    private void Awake()
    {
        m_Job = null;
    }

    public bool HasJob()
    {
        return m_Job != null;
    }

}
