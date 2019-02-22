using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public Inventory Inventory { get; protected set; }
    public Employer Employer { get; protected set; }

    [SerializeField][ReadOnly]
    private List<Building> m_Buildings = new List<Building>();
    public IEnumerable<Building> Buildings { get { return m_Buildings.AsReadOnly(); } }

    void Start()
    {
        Inventory = GetComponent<Inventory>();
        Employer = GetComponent<Employer>();
    }

    public void AddBuilding(Building b)
    {
        if (!m_Buildings.Contains(b))
        {
            m_Buildings.Add(b);
            b.Plot = this;
        }
    }

    public void RemoveBuilding(Building b)
    {
        m_Buildings.Remove(b);
        b.Plot = null;
    }
}
