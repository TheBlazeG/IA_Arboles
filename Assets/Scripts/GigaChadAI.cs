using UnityEngine;
using UnityEngine.AI;

public class GigaChadAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out agent);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
