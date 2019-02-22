using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pop : MonoBehaviour
{
    public Inventory Inventory { get; protected set; }
    public Employee Employee { get; protected set; }
    public Resident Resident { get; protected set; }

    public StateController StateController { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; protected set; }

    void Start()
    {
        Inventory = GetComponent<Inventory>();
        Employee = GetComponent<Employee>();
        Resident = GetComponent<Resident>();
        StateController = GetComponent<StateController>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    public bool HasJob()
    {
        if (Employee == null)
            return false;
        return !Employee.Job.Type.Equals(Job.JobType.Unemployed);
    }

    public void Work()
    {
        if (!HasJob())
            return;
        

        NavMeshAgent.SetDestination(Employee.Job.Tasks.First().Location.position);
    }
}
