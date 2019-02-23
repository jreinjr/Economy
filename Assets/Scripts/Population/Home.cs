using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField][ReadOnly]
    private List<Resident> m_Residents = new List<Resident>();
    public IEnumerable<Resident> Residents { get { return m_Residents.AsReadOnly(); } }

    [SerializeField]
    private int m_MaxResidents;
    public int MaxResidents { get { return m_MaxResidents; } protected set { m_MaxResidents = value; } }

    public bool HasVacancy()
    {
        return m_Residents.Count < m_MaxResidents;
    }

    public void AddResident(Resident r)
    {
        if (!m_Residents.Contains(r) && HasVacancy())
        {
            m_Residents.Add(r);
            r.Home = this;
        }
    }

    public void EvictResident(Resident r)
    {
        m_Residents.Remove(r);
        r.Home = null;
    }

    public void SetMaxResidents(int i)
    {
        m_MaxResidents = i;
    }
}
