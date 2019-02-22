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
        var employer = field.Employer;
        var employee = pop.Employee;

        var home = building.Home;
        var resident = pop.Resident;

        employer.HireEmployee(employee, employer.AvailableJobs.First());

        home.SetMaxResidents(2);
        home.AddResident(resident);

        plot.AddBuilding(building);

        pop.Work();
    }
}
