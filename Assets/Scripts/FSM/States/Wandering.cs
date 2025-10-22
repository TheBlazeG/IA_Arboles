using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "WanderState", menuName = "FSM/States/WanderState")]
public class Wander : State
{
    NavMeshAgent agent;
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        agent.destination = stateMachine.route[stateMachine.currentWaypoint].position;
        
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
        if (Vector3.Distance(stateMachine.transform.position, stateMachine.route[stateMachine.currentWaypoint].position)<2f)
        {

            if (stateMachine.currentWaypoint < 3)
            {
                stateMachine.currentWaypoint++;
            }
            else 
            {
                stateMachine.currentWaypoint = 0;
            }
            agent.destination = stateMachine.route[stateMachine.currentWaypoint].position;
        }
    }
}
