using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private List<Vector2> points;
    private int _currentPointIndex = 0;
    private void Awake()
    {
        var transform = GetComponentsInChildren<Transform>(true);
        foreach(var t in transform)
        {
            points.Add(t.position);
        }
    }

    public Vector2 GetNextWaypointPosition()
    {
        _currentPointIndex++;
        if (_currentPointIndex >= points.Count)
        {
            _currentPointIndex = 0;
        }

        return points[_currentPointIndex];
    }
}
