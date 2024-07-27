using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class RogueMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _waypointsSet;

    private int _currentWaypointIndex;
    private Transform[] _waypoints;

    private void Start()
    {
        if (_waypointsSet.childCount != 0)
        {
            _waypoints = new Transform[_waypointsSet.childCount];

            for (int i = 0; i < _waypointsSet.childCount; i++)
            {
                _waypoints[i] = _waypointsSet.GetChild(i);
            }
        }
    }

    private void Update()
    {
        MoveThroughWaypoints();
    }

    private void MoveThroughWaypoints()
    {
        if (transform.position == _waypoints[_currentWaypointIndex].position)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _moveSpeed * Time.deltaTime);
    }
}