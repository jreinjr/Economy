using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Inventory Inventory { get; protected set; }
    public Employer Employer { get; protected set; }
    public Home Home { get; protected set; }

    [SerializeField][ReadOnly]
    private Plot m_Plot;
    public Plot Plot { get { return m_Plot; } internal set { m_Plot = value; } }

    void Start()
    {
        Inventory = GetComponent<Inventory>();
        Employer = GetComponent<Employer>();
        Home = GetComponent<Home>();
    }
    
}
