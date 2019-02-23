using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employer : MonoBehaviour
{
    [SerializeField][ReadOnly]
    private List<Employee> m_Employees = new List<Employee>();
    public IEnumerable<Employee> Employees { get { return m_Employees.AsReadOnly(); } }

    [SerializeField]
    private List<Job> m_AvailableJobs = new List<Job>();
    public IEnumerable<Job> AvailableJobs { get { return m_AvailableJobs.AsReadOnly(); } }

    public bool HasAvailableJobs()
    {
        return m_AvailableJobs.Count > 0;
    }

    public void HireEmployee(Employee e, Job j)
    {
        if (!m_Employees.Contains(e) && m_AvailableJobs.Contains(j))
        {
            m_Employees.Add(e);
            m_AvailableJobs.Remove(j);
            e.Employer = this;
            e.Job = j;
        }
    }

    public void FireEmployee(Employee e)
    {
        m_AvailableJobs.Add(e.Job);
        m_Employees.Remove(e);
        e.Employer = null;
        e.Job = null;
    }

    public void AddJob(Job j)
    {
        m_AvailableJobs.Add(j);
    }

    public void RemoveJob(Job j)
    {
        m_AvailableJobs.Remove(j);
    }
}
