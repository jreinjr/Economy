using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Pop : MonoBehaviour
{
    public Inventory Inventory { get; protected set; }
    public Employee Employee { get; protected set; }
    public Resident Resident { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; protected set; }
    public JobDescription.TaskType CurrentTask { get; protected set; }

    public const float NEAR_WORK_DIST = 2f;

    void Start()
    {
        Inventory = GetComponent<Inventory>();
        Employee = GetComponent<Employee>();
        Resident = GetComponent<Resident>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentTask = JobDescription.TaskType.Idle;

        GameClock.OnTick += OnTick;
    }

    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        if (e.time >= 8 && e.time < 20)
            Work();

        else if (e.time >= 20 || e.time < 8)
            Home();
    }

    void Work()
    {
        if (!Employee.HasJob())
            return;


        if (Vector3.SqrMagnitude(transform.position - Employee.Job.transform.position) < NEAR_WORK_DIST)
        {
            Inventory.Add(new ResourceBundle()
        }

        NavMeshAgent.SetDestination(Employee.Job.transform.position);
        CurrentTask = Employee.Job.description.type;
    }
    

    void Home()
    {
        if (!Resident.HasHome())
            return;

        NavMeshAgent.SetDestination(Resident.Home.transform.position);
        CurrentTask = JobDescription.TaskType.Idle;
    }
}
