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
        
        return enemy.isDetectedPlayer ? NodeState.FAILURE : NodeState.SUCCESS;
    }

    public void FindPath()
    {
        var _distance = Vector3.Distance(tempPath[0].transform.position, agent.transform.position);
        agent.speed = 2f;
        agent.angularSpeed = 180f;
        
        if (tempPath.Count > 0)
        {
            agent.isStopped = false;
            agent.SetDestination(tempPath[0].transform.position);
        }

        if (_distance < 1.5f)
        {
            tempPath.Remove(tempPath[0]);
        }

        if (_distance < 1.5f && tempPath.Count == 1)
        {
            tempPath.AddRange(savedPath);
        }
    }
}
