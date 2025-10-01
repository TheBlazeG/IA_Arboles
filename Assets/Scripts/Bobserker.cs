using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
public class Bobserker : MonoBehaviour
{
    private float health = 50;
    private float maxHealth = 50;

    float criticalHealthLimit = 0.3f;

    public Transform player;
    [SerializeField] SphereCollider sixthSense;


    float distanceToPlayer;
    float fleeDistance = 12f;
    private bool lineOfSight = false;

    private Dictionary<string, float> actionScores;

    public Transform[] patrolPoints = new Transform[4];
    private int patrolIndex = 0;
    public float distanceCheck = 1;
    bool inRage = false;


    NavMeshAgent agentSmith;
    public TextMeshProUGUI fleeText;
    public TextMeshProUGUI chaseText;

    public float viewDistance = 10f;
    public float viewAngle = 45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out agentSmith);
        sixthSense.enabled=false;
        actionScores = new Dictionary<string, float>()
        {
            { "Flee", 0f},
            { "Chase", 0f},
            { "Patrol", 0f},
        };
        gameObject.TryGetComponent(out sixthSense);
    }

    // Update is called once per frame
    void Update()
    {
        if (health<15)
        {
            inRage = true;
            agentSmith.speed = 15;
            agentSmith.angularSpeed = 60;
            agentSmith.acceleration = 12;
        }
        //Sense
        if (!inRage)
        {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        lineOfSight = PlayerInFOV();
        }
        else
        {
            sixthSense.enabled = true;
        }
        //Ray ray = new Ray(transform.position+(Vector3.up*.5f),player.position-transform.position);
        //if (Physics.Raycast(ray,out RaycastHit hit))
        //{
        //    lineOfSight = hit.collider.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement _);
        //}
        if (Vector3.Distance(patrolPoints[patrolIndex].position,transform.position)<distanceCheck)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }

        float healthRatio = Mathf.Clamp01(health/maxHealth);
        float distanceRatio = Mathf.Clamp01(distanceToPlayer / fleeDistance);

        if (healthRatio <= criticalHealthLimit) { distanceRatio = 0; }

        float riskFactor= (1-healthRatio)*(1-distanceRatio);

        float aggroFactor = healthRatio * distanceRatio;

        float total = riskFactor + aggroFactor;


        riskFactor /= total;
        aggroFactor /= total;
        aggroFactor *= healthRatio > criticalHealthLimit ? 1:0;

        //PLAN
        UpdatePrediction();
        actionScores["Flee"] = riskFactor * 10 * (lineOfSight == true ? 1 : 0);
        actionScores["Chase"]= aggroFactor * 10 * (lineOfSight ? 1 : 0);
        actionScores["Patrol"] = 3f;

        fleeText.text = "FlEE = " + actionScores["Flee"];
        chaseText.text = "CHASE = " + actionScores["Chase"];


        //ACT
        string chosenAction = actionScores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        if (inRage && lineOfSight)
        {
            chosenAction="Chase";
        }
        switch (chosenAction)
        {
            case "Flee":
                Flee();
                break;
            case "Chase":
                Chase();
                break;
            case "Patrol":
                Patrol();
                break ;
            default:
                break;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lineOfSight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lineOfSight = false;
        }
    }

    private bool PlayerInFOV()
    {
        Vector3 dirToPlayer = (player.position- transform.position).normalized;

        if (distanceToPlayer > viewDistance)
        {
            return false;
        }

        float angleToPlayer = Vector3.Angle(transform.forward, dirToPlayer);
        if (angleToPlayer > viewAngle / 2)
        {
            return false;
        }
        if(Physics.Raycast(transform.position,dirToPlayer,out RaycastHit hit, distanceToPlayer))
        {
            if(hit.collider.gameObject.TryGetComponent(out PlayerMovement _))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public void GetHit()
    {
        health -= 9;
        Debug.Log("Was Hit! Only Have " + health + " hp left");
    }

    private void Flee()
    {
        Vector3 fleeDir = (transform.position - player.position).normalized*2;
        if (NavMesh.SamplePosition(fleeDir,out NavMeshHit hit,1,NavMesh.AllAreas))
        {
            agentSmith.SetDestination(fleeDir);  
        }
        else
        {
            agentSmith.SetDestination(FindFleeAlternative(fleeDir));
        }
        agentSmith.SetDestination(fleeDir);
    }

    private void Chase()
    {
        agentSmith.SetDestination(predictedPlayerPos);
    }

    private void Patrol()
    { agentSmith.SetDestination(patrolPoints[patrolIndex].position); }

    #region FleeAlternative
    public float maxDistanceFromDirection = 100;
    public float step =10f;
    public float fleeLength = 3f;

    private Vector3 FindFleeAlternative(Vector3 fleeDirection)
    {
        float maxDistanceFromPlayer =0;
        Vector3 bestPosition = transform.position;

        for(float angle = -maxDistanceFromDirection; angle <=maxDistanceFromDirection; angle+=step)
        {
            Vector3 dir = Quaternion.Euler(0, angle, 0)*fleeDirection;
            Vector3 candidate = transform.position + dir;

            if (NavMesh.SamplePosition(candidate,out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                float distToPlayer = Vector3.Distance(transform.position, player.position);
                if (distToPlayer>maxDistanceFromPlayer)
                {
                    maxDistanceFromPlayer = distToPlayer;
                    bestPosition = hit.position;
                }
            }
        }
        return bestPosition;
    }
    #endregion

    #region predict
    Vector3 lastPlayerPosition = new Vector3();
    Vector3 predictedPlayerPos = new Vector3();

    private void UpdatePrediction()
    {
        Vector3 currentPlayerPosition = player.position;
        Vector3 moveDirection = (currentPlayerPosition -lastPlayerPosition).normalized;

        float predictionDistance = distanceToPlayer * .5f;
        
        predictedPlayerPos = currentPlayerPosition+moveDirection * predictionDistance;  
        lastPlayerPosition = currentPlayerPosition;

    }

    #endregion
}
