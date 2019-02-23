using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType
    {
        Idle,
        Farming
    }

[System.Serializable]
[CreateAssetMenu(menuName = "Economy/Simple Job Description")]
public class JobDescription : ScriptableObject
{
    public TaskType type;
    public float duration;
}