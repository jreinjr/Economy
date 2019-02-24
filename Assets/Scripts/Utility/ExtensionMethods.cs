using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public static class ExtensionMethods
{
    public static float GetLength(this NavMeshPath path)
    {
        float lng = 0.0f;
        
        if ((path.status != NavMeshPathStatus.PathInvalid) && (path.corners.Length > 1))
        {
            for (int i = 1; i < path.corners.Length; ++i)
            {
                lng += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
        }

        return lng;
    }
}
