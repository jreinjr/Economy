using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEmployee
{
    Inventory Inventory { get; }
    NavMeshAgent NavMeshAgent { get; }
}
[RequireComponent(typeof(IEmployee))]
public class Employee : MonoBehaviour
{
    private IEmployee m_IEmployee;

    [SerializeField][ReadOnly]
    private Job m_Job;
    public Job Job { get { return m_Job; } internal set { m_Job = value; } }

    [SerializeField][ReadOnly]
    private Employer m_Employer;
    public Employer Employer { get { return m_Employer; } internal set { m_Employer = value; } }

    public const float NEAR_WORK_DIST = 2f;

    
    public SkillBundle skills = new SkillBundle();

    private void Awake()
    {
        m_IEmployee = GetComponent<IEmployee>();
        m_Job = null;
    }

    public void GoWork()
    {
        if (Job == null || Job.transform == null)
            return;

        m_IEmployee.NavMeshAgent.SetDestination(Job.transform.position);

        Gather();
    }

    public bool Gather()
    {
        bool withinJobRange = Vector3.SqrMagnitude(transform.position - Job.transform.position) < NEAR_WORK_DIST;
        if (withinJobRange)
        {
            var j = (GatherJobDescription)Job.description;
            m_IEmployee.Inventory.Add(new ResourceBundle(Resource.Food, 0.1f));
            skills.FarmingSkill += 0.0005f;
            return true;
        }
        else
        {
            Debug.Log("Was out of range to gather - moving to job now!");
            m_IEmployee.NavMeshAgent.SetDestination(Job.transform.position);
            return false;
        }
    }

    public bool HasJob()
    {
        return m_Job != null;
    }

    public void FindJob()
    {
        if (HasJob())
            return;

        var newEmployer =
                GameManager.instance.Employers.Where(p => p.HasAvailableJobs())
                .OrderBy(p => (p.transform.position - transform.position).sqrMagnitude)
                .FirstOrDefault();

        newEmployer.HireEmployee(this, newEmployer.AvailableJobs.FirstOrDefault());
    }


}
