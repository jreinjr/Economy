using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : MonoBehaviour
{
    [SerializeField]
    private Home m_Home;
    public Home Home { get { return m_Home; } internal set { m_Home = value; } }

    private void Awake()
    {
        m_Home = null;
    }

    public bool HasHome()
    {
        return m_Home != null;
    }
}
