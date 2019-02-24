using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Economy/Goals/Has Job")]
public class HasJobGoal : Goal
{
    [SerializeField]
    private JobType m_DesiredJob;

    public void Initialize(Actor a, string d, JobType j)
    {
        base.Initialize(a, d);
        m_DesiredJob = j;
    }

    public override float GetCost()
    {
        if (IsAchieved()) return 0;

        if (GetAvailableJob() == null)
            return 1000;

        else return 0;
    }

    private Job GetAvailableJob()
    {
        var availableJob = GameManager.instance.Employers
            .Where(p => p.HasAvailableJobs())
            .Select(q => q.AvailableJobs.Where(z => z.description.type == JobType.Farmer).FirstOrDefault())
            .FirstOrDefault();

        return availableJob;
    }

    public override bool IsAchieved()
    {
        var iHaveMyDreamJob = m_Actor.IActor.Employee.Job.description.type == m_DesiredJob;

        return iHaveMyDreamJob;
    }

    public override void AttemptGoal()
    {
        var availableJob = GetAvailableJob();
        availableJob.Employer.HireEmployee(m_Actor.IActor.Employee, availableJob);
    }
}
