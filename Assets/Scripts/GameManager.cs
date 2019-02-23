using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Employee> Employees;
    public List<Employer> Employers;
    public List<Home> Homes;
    public List<Resident> Residents;

    private void Start()
    {
        GameClock.OnTick += OnTick;

        Employers = (FindObjectsOfType(typeof(Employer)) as Employer[]).ToList();
        Employees = (FindObjectsOfType(typeof(Employee)) as Employee[]).ToList();
        Homes = (FindObjectsOfType(typeof(Home)) as Home[]).ToList();
        Residents = (FindObjectsOfType(typeof(Resident)) as Resident[]).ToList();
        
    }

    void DoHiring()
    {
        foreach (var unemployed in Employees.Where(p => !p.HasJob()))
        {
            var newEmployer =
                Employers.Where(p => p.HasAvailableJobs())
                .OrderBy(p => (p.transform.position - unemployed.transform.position).sqrMagnitude)
                .FirstOrDefault();

            newEmployer.HireEmployee(unemployed, newEmployer.AvailableJobs.FirstOrDefault());
        }
    }

    void DoResidency()
    {
        foreach(var homeless in Residents.Where(p => !p.HasHome()))
        {
            Debug.Log(homeless.gameObject.name);
            var newHome =
                Homes.Where(p => p.HasVacancy())
                .OrderBy(p => (p.transform.position - homeless.transform.position).sqrMagnitude)
                .FirstOrDefault();

            newHome.AddResident(homeless);
        }
    }

    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        Debug.Log(e.time);
        DoHiring();
        DoResidency();
    }
}
