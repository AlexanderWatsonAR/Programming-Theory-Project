using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{

    public static Vector3 DirectionToTarget(this Vector3 position, Vector3 target)
    {
        return (target - position).normalized;
    }

}
