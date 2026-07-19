using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();

    public float moveSpeed = 8f;
    public float rotateSpeed = 5f;
    public float reachDistance = 1f;

    private int waypointIndex = 0;

    void Update()
    {
        if (wayPoints.Count == 0)
            return;

        Transform target = wayPoints[waypointIndex];

        // Move
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime);

        // Rotate
        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rot,
                rotateSpeed * Time.deltaTime);
        }

        // Next waypoint
        if (Vector3.Distance(transform.position, target.position) < reachDistance)
        {
            waypointIndex++;

            if (waypointIndex >= wayPoints.Count)
            {
                waypointIndex = 0; // Repeat
            }
        }
    }
}