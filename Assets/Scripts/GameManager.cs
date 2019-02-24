using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Employee> Employees;
    public List<Employer> Employers;
    public List<Home> Homes;
    public List<Resident> Residents;

    private void Awake()
    {
        instance = this;

        Employers = (FindObjectsOfType(typeof(Employer)) as Employer[]).ToList();
        Employees = (FindObjectsOfType(typeof(Employee)) as Employee[]).ToList();
        Homes = (FindObjectsOfType(typeof(Home)) as Home[]).ToList();
        Residents = (FindObjectsOfType(typeof(Resident)) as Resident[]).ToList();
        
    }

    private void Start()
    {
        GameClock.OnTick += OnTick;
    }

    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        Debug.Log(e.time);
    }
}
