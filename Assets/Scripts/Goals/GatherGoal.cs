using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Economy/Goals/Gather")]
public class GatherGoal : Goal
{
    [SerializeField]
    private ResourceBundle m_Resource;
    
    public void Initialize(Actor a, string d, ResourceBundle r)
    {
        base.Initialize(a, d);
        m_Resource = r;
    }

    public ResourceBundle Resource { get { return m_Resource; } protected set { m_Resource = value; } }

    public override float GetCost()
    {
        var a = m_Actor.IActor;
        var path = new NavMeshPath();
        a.NavMeshAgent.CalculatePath(a.Employee.Job.transform.position, path);

        var travelTime = path.GetLength();
        Debug.Log(travelTime);
        return 0;
    }

    public override bool IsAchieved()
    {
        throw new System.NotImplementedException();
    }

    public override void AttemptGoal()
    {
        m_Actor.IActor.Employee.Gather();
    }
}
