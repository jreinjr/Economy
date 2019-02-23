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
    public Maintenence Maintenence { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; protected set; }
    public TaskType CurrentTask { get; protected set; }

    public const float NEAR_WORK_DIST = 2f;

    void Awake()
    {
        Inventory = GetComponent<Inventory>();
        Employee = GetComponent<Employee>();
        Resident = GetComponent<Resident>();
        Maintenence = GetComponent<Maintenence>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentTask = TaskType.Idle;
    }

    private void Start()
    {
        GameClock.OnTick += OnTick;
    }

    private void OnDisable()
    {
        GameClock.OnTick -= OnTick;
    }

    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        if (e.time == 0)
            Maintain();

        if (e.time >= 6 && e.time < 20)
            Work();

        else if (e.time >= 20 || e.time < 6)
            Home();
    }

    void Maintain()
    {
        if (Inventory.TryPurchase(Maintenence.DailyMaintenence) == false)
            KillPop();
    }

    void KillPop()
    {
        Debug.Log("Sorry! I died!");
        Destroy(gameObject);
    }

    void Work()
    {
        if (Employee == null)
            return;
        if (Employee.Job == null)
            return;
        if (Employee.Job.transform == null)
            return;

        if (Vector3.SqrMagnitude(transform.position - Employee.Job.transform.position) < NEAR_WORK_DIST)
        {
            var j = (GatherJobDescription)Employee.Job.description;
            Inventory.Add(j.output * Employee.skills.FarmingSkill);
            Employee.skills.FarmingSkill += 0.0005f;
        }

        NavMeshAgent.SetDestination(Employee.Job.transform.position);
        CurrentTask = Employee.Job.description.type;
    }
    

    void Home()
    {
        if (!Resident.HasHome())
            return;

        NavMeshAgent.SetDestination(Resident.Home.transform.position);
        CurrentTask = TaskType.Idle;
    }
}
