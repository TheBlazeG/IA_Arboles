using BehaviourTrees;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DekuScrub : MonoBehaviour
{
    public BehaviourTree dekuTree;
    private NavMeshAgent navMeshAgent;
    public List<Transform> PatrolPoints = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        dekuTree = new BehaviourTree("El Deku Tree");
        IStrategy patrolStrategy = new PatrolStrategy(transform, navMeshAgent, PatrolPoints, 3f);
        dekuTree.SetstoXD(new Leaf("Patrullando",patrolStrategy));
    }

    // Update is called once per frame
    void Update()
    {
        dekuTree.Process();
    }
}
