using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WatchmenEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] points;

    private NavMeshAgent _agent;
    private int pointCounter;

    void Start()
    {
        pointCounter = 0;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = speed;
    }

    void Update()
    {
        if (_agent.SetDestination(points[pointCounter].transform.position))
            pointCounter++;
        if (pointCounter == points.Length)
            pointCounter = 0;
    }
}
