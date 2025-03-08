using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private List<Vector2> points;
    private int _currentPointIndex = 0;
    private void Awake()
    {
        var transforms = GetComponentsInChildren<Transform>(true);
        foreach(var t in transforms)
        {
            points.Add(t.position);
        }
    }

    public Vector2 GetNextWaypointPosition()
    {
        int prevIndex = _currentPointIndex;
        _currentPointIndex++;
        if (_currentPointIndex >= points.Count)
        {
            _currentPointIndex = 0;
        }

        Debug.DrawLine(points[prevIndex], points[_currentPointIndex], Color.magenta, 1);

        return points[_currentPointIndex];
    }

    public void ClaimAtNearestWaypoint(Vector2 fromPosition)
    {

    }

    private void OnDrawGizmos()
    {
        var transforms = GetComponentsInChildren<Transform>(true);

        if (transforms.Length >= 2 )
        {
            for (int i = 0, j = 1; j < transforms.Length; i++, j++)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transforms[i].position, transforms[j].position);
            }

            Gizmos.DrawLine(transforms[transforms.Length - 1].position, transforms[0].position);
        }
    }
}
