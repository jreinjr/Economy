using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JobType
    {
        Idle,
        Farmer
    }

[System.Serializable]
[CreateAssetMenu(menuName = "Economy/Simple Job Description")]
public class JobDescription : ScriptableObject
{
    public JobType type;
    public float duration;
}