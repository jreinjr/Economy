using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : MonoBehaviour
{
    [SerializeField][ReadOnly]
    private Home m_Home;
    public Home Home { get { return m_Home; } internal set { m_Home = value; } }
}
