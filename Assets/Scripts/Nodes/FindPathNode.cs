using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPathNode : Node
{
    private readonly List<GameObject> savedPath = new List<GameObject>();
    private readonly List<GameObject> tempPath= new List<GameObject>();
    private NavMeshAgent agent;
    private EnemyAI enemy;
    private bool isDetected, isDistracted, isSearching;

    public FindPathNode(List<GameObject> _path, NavMeshAgent _agent, EnemyAI _enemmy)
    {
        savedPath.AddRange(_path);
        tempPath.AddRange(_path);
        agent = _agent;
        enemy = _enemmy;
    }

    public override NodeState Evaluate()
    {
        FindPath();
        
        return NodeState.SUCCESS;
    }

    public void FindPath()
    {
        var _distance = Vector3.Distance(tempPath[0].transform.position, agent.transform.position);
        agent.speed = 2f;
        agent.angularSpeed = 180f;
        // Debug.Log($"Distance left : {_distance}");
        
        if (tempPath.Count > 0)
        {
            // Debug.Log($"Set Path");
            agent.isStopped = false;
            agent.SetDestination(tempPath[0].transform.position);
        }

        if (_distance < 1.5f)
        {
            // Debug.Log($"Remove path");
            tempPath.Remove(tempPath[0]);
        }

        if (_distance < 1.5f && tempPath.Count == 1)
        {
            // Debug.Log($"Add path for loop");
            tempPath.AddRange(savedPath);
        }
    }
}
