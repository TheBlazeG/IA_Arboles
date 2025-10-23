using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
public class AISpaV2 : MonoBehaviour
{
    public Transform player;
    public float fleeRange = 3f;
    private NavMeshAgent agent;

    

    public Transform[] patrolPoints = new Transform[3];

    private int patrolIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out  agent);
    }

    // Update is called once per frame
    void Update()
    {
        //Sense
        float distance = Vector3.Distance(transform.position, player.position);
        Ray ray = new Ray(transform.position + (Vector3.up * .5f), player.position - transform.position);
        bool los = Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity);
        if (hit.collider.gameObject.TryGetComponent(out PlayerMovement playah))
        {
            los = true;
        }
        float patrolPointDistance = Vector3.Distance(transform.position, patrolPoints[patrolIndex].position);
        if (los == false)
        {
            Debug.Log("Whut");

            if (patrolPointDistance < .5f)
            {
                patrolIndex = (patrolIndex+1) % patrolPoints.Length;
                Debug.Log("WTF");
            }    
            
        }

        //Plan
        if (los==true)
        {
         if (distance > fleeRange && los == true)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            Vector3 dir = (transform.position - player.position).normalized;
            Vector3 fleePos = transform.position + dir *5;
            agent.SetDestination(fleePos);
        }
        }
        else
        {
            agent.SetDestination(patrolPoints[patrolIndex].position);
        }
        
        
    }
}
