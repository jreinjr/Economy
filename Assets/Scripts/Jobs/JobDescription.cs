using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Economy/Simple Job Description")]
public class JobDescription : ScriptableObject
{
    public enum TaskType
    {
        Idle,
        Farming
    }
    public TaskType type;
    public float duration;
}