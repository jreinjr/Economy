using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public interface IResident
{
    NavMeshAgent NavMeshAgent { get; }
}
[RequireComponent(typeof(IResident))]
public class Resident : MonoBehaviour
{
    private IResident m_IResident;

    [SerializeField]
    private Home m_Home;
    public Home Home { get { return m_Home; } internal set { m_Home = value; } }

    private void Awake()
    {
        m_IResident = GetComponent<IResident>();
        m_Home = null;
    }

    public void GoHome()
    {
        if (!HasHome())
            return;

        m_IResident.NavMeshAgent.SetDestination(Home.transform.position);
    }

    public bool HasHome()
    {
        return m_Home != null;
    }

    public void FindHome()
    {
        if (HasHome())
            return;

        var newHome =
                GameManager.instance.Homes.Where(p => p.HasVacancy())
                .OrderBy(p => (p.transform.position - transform.position).sqrMagnitude)
                .FirstOrDefault();

        newHome.AddResident(this);
    }
}
