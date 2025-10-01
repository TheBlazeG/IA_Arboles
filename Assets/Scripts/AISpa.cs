using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
public class AISpa : MonoBehaviour
{
    public Transform player;
    public float fleeRange = 3f;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out agent);
    }

    // Update is called once per frame
    void Update()
    {
        //empieza percepci�n (sense)
        float distance = Vector3.Distance(transform.position,player.position);
        //Empieza planeaci�n
        if (distance < fleeRange)
            //Empieza Acci�n
        {
            Vector3 dir = (transform.position - player.position).normalized;
            Vector3 fleePos = transform.position + dir * 5f;
            agent.SetDestination(fleePos);
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }
}
