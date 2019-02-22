using System;
using UnityEngine;

[System.Serializable]
public class Task
{
    public enum TaskType
    {
        Gather,
        Store
    }
    public TaskType Type;
    public Transform Location;
    public float Duration;
}
