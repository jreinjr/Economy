using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Pop : MonoBehaviour, IActor, IEmployee, IResident
{
    public Inventory Inventory { get; protected set; }
    public Actor Actor { get; protected set; }
    public Employee Employee { get; protected set; }
    public Resident Resident { get; protected set; }
    public Maintenence Maintenence { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; protected set; }   

    void Awake()
    {
        Inventory = GetComponent<Inventory>();
        Actor = GetComponent<Actor>();
        Employee = GetComponent<Employee>();
        Resident = GetComponent<Resident>();
        Maintenence = GetComponent<Maintenence>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

}
