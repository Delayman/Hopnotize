using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    #region Enemy Setting Variable
    
    [FormerlySerializedAs("_pratolPaths")] [SerializeField] private List<GameObject> pratolPaths = new List<GameObject>();
    [SerializeField] private Transform eyeLevel;
    [SerializeField] private float maxDistance = 10f;

    public Transform playerTransform;

    private Material material;
    private NavMeshAgent agent;

    private Node topNode;
    public bool isDetectedPlayer;

    #endregion
    
    private void Awake()
    {
        pratolPaths = GameObject.FindGameObjectsWithTag("EnemyPath").ToList();

        agent = GetComponent<NavMeshAgent>();
        isDetectedPlayer = false;
    }

    private void Start()
    {
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        var _chaseNode = new ChaseNode(playerTransform, agent, this);
        var _findPathNode = new FindPathNode(pratolPaths, agent, this);

        var _chaseSequnce = new Sequnce(new List<Node> { _chaseNode });
        var _pratol = new Sequnce(new List<Node> { _findPathNode });

        topNode = new Selector(new List<Node> {_pratol, _chaseSequnce });
    }

    private void Update()
    {
        topNode.Evaluate();

        CastRay();

        if (topNode.NodeState == NodeState.FAILURE)
        {
            agent.isStopped = true;
        }
        
    }

    private void CastRay()
    {
        var ray = new Ray(eyeLevel.position, this.transform.forward);
        Debug.DrawRay(eyeLevel.position, this.transform.forward, Color.red);

        if(Physics.SphereCast(ray ,1f ,out var _hit, maxDistance))
        {
            if(_hit.collider.gameObject.tag == "Player")
            {
                isDetectedPlayer = true;
                playerTransform = _hit.collider.gameObject.transform;
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        SceneManager.LoadScene("Gameover_scene");
    }
}
