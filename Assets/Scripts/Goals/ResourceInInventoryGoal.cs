using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
[CreateAssetMenu(menuName = "Economy/Goals/Resource In Inventory")]
public class ResourceInInventoryGoal : Goal
{
    [SerializeField]
    private ResourceBundle m_Resource;
    public ResourceBundle Resource { get { return m_Resource; } protected set { m_Resource = value; } }

    [SerializeField]
    private Inventory m_TargetInventory;
    public Inventory TargetInventory { get { return m_TargetInventory; } protected set { m_TargetInventory = value; } }

    public void Initialize(Actor a, string d, ResourceBundle r, Inventory i)
    {
        base.Initialize(a, d);
        Resource = r;
        TargetInventory = i;
    }

    public void SetTargetInventory(Inventory i)
    {
        if (TargetInventory != null)
            Debug.Log("I already had a target inventory before changing it");
        TargetInventory = i;
    }

    public override bool IsAchieved()
    {
        return m_TargetInventory.CanAfford(m_Resource);
    }

    public override float GetCost()
    {
        var prereq_sum = Prerequisites.Select(p => p.GetCost()).Sum();
        var opt_sum = DecideFromOptions().GetCost();
        var inv_travel_time = 0f;
        var a = m_Actor.IActor;

        // No extra cost if for travelling to your own inventory
        if (TargetInventory != a.Inventory)
        {
            var path = new NavMeshPath();
            a.NavMeshAgent.CalculatePath(m_TargetInventory.transform.position, path);

            inv_travel_time = path.GetLength();
            Debug.Log(inv_travel_time);
        }

        return prereq_sum + opt_sum + inv_travel_time;
    }
}