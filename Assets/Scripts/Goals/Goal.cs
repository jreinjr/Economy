using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public abstract class Goal : ScriptableObject
{
    protected Actor m_Actor;

    [SerializeField]
    private string m_Description;
    public string Description { get { return m_Description; } protected set { m_Description = value; } }

    [SerializeField]
    private int m_Priority = 50;
    public int Priority { get { return m_Priority; } protected set { m_Priority = value; } }

    private float m_Cost;
    public float Cost { get { return GetCost(); } protected set { m_Cost = value; } }

    [SerializeField][Expandable]
    private List<Goal> m_Prerequisites;
    public List<Goal> Prerequisites { get { return m_Prerequisites; } protected set { m_Prerequisites = value; } }

    [SerializeField][Expandable]
    private List<Goal> m_Options;
    public List<Goal> Options { get { return m_Options; } protected set { m_Options = value; } }

    public virtual void Initialize(Actor a, string d)
    {
        Initialize(a, d, new List<Goal>(), new List<Goal>());
    }

    public virtual void Initialize(Actor a, string d, List<Goal> p, List<Goal> o)
    {
        m_Actor = a;
        Description = d;
       
        Prerequisites.AddRange(p);
        Options.AddRange(o);

        foreach(var prereq in Prerequisites)
        {
            prereq.Initialize(a);
        }
    }

    public abstract bool IsAchieved();

    public abstract float GetCost();

    public virtual Goal DecideFromOptions()
    {
        return m_Options.OrderBy(g => g.GetCost()).FirstOrDefault();
    }

    public virtual void AttemptGoal()
    {
        DecideFromOptions().AttemptGoal();
    }

    public override string ToString()
    {
        var speech = "I want to " + Description + ".";
        if (Prerequisites.Count > 0)
        {
            speech += " I must ";
            foreach (var prereq in Prerequisites)
            {
                speech += prereq.ToString() + ", ";
            }
        }
        if (Options.Count > 0)
        {
            speech += " I will ";
            speech += DecideFromOptions().ToString();
        }
        Debug.Log(speech);
        return speech;
    }

}