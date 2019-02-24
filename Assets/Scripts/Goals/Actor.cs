using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IActor
{
    Employee Employee { get; }
    Resident Resident { get; }
    Inventory Inventory { get; }
    NavMeshAgent NavMeshAgent { get; }
    Transform transform { get; }
}

[RequireComponent(typeof(IActor))]
public class Actor : MonoBehaviour
{
    private IActor m_IActor;
    public IActor IActor { get { return m_IActor; } protected set { m_IActor = value; } }

    [Expandable]
    public ResourceInInventoryGoal m_goal;

    private void Awake()
    {
        m_IActor = GetComponent<IActor>();
        m_goal.SetTargetInventory(m_IActor.Inventory);
    }

    private void Start()
    {
        GameClock.OnTick += OnTick;
        m_goal.Initialize(this, "");
        m_goal.ToString();
    }

    private void OnDisable()
    {
        GameClock.OnTick -= OnTick;
    }


    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        /*
        if (!m_IActor.Employee.HasJob())
            m_IActor.Employee.FindJob();

        if (!m_IActor.Resident.HasHome())
            m_IActor.Resident.FindHome();

        if (e.time >= 6 && e.time < 20)
            m_IActor.Employee.GoWork();

        else if (e.time >= 20 || e.time < 6)
            m_IActor.Resident.GoHome();
            */
    }
}
