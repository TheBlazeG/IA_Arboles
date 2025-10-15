using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "CleaningState", menuName = "FSM/States/CleaningState")]
public class Cleaning : State
{
    NavMeshAgent agent;
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        agent.destination = stateMachine.route[stateMachine.currentWaypoint].position;
        
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
        if (Vector3.Distance(stateMachine.transform.position, stateMachine.route[stateMachine.currentWaypoint].position)<1f)
        {

            if (stateMachine.currentWaypoint < 4)
            {

                stateMachine.route[stateMachine.currentWaypoint].gameObject.SetActive(false);
                stateMachine.currentWaypoint++;
            }
            else 
            {
                stateMachine.route[stateMachine.currentWaypoint].gameObject.SetActive(false);
                stateMachine.currentWaypoint = 0;
            }
            agent.destination = stateMachine.route[stateMachine.currentWaypoint].position;
        }
    }
}
