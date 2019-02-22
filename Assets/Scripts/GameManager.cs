using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Building building;
    public Pop pop;
    public Plot plot;
    public Plot field;

    private void Start()
    {
        GameClock.OnTick += OnTick;

        var employer = field.Employer;
        var employee = pop.Employee;

        var home = building.Home;
        var resident = pop.Resident;

        if (employer.AvailableJobs.Count() > 0)
            employer.HireEmployee(employee, employer.AvailableJobs.First());

        home.AddResident(resident);

        plot.AddBuilding(building);
        
    }

    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        Debug.Log(e.time);
    }
}
