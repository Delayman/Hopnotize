using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private EnemyAI enemy;
    private float chaseTimer;

    public ChaseNode(Transform _target, NavMeshAgent _agent, EnemyAI _enemy)
    {
        this.agent = _agent;
        this.enemy = _enemy;
    }
    public override NodeState Evaluate()
    {
        target = enemy.playerTransform;
        agent.SetDestination(target.transform.position);

        return chaseTimer <= 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
