using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "FleeingState", menuName = "FSM/States/FleeingState")]
public class Fleeing : State
{
    NavMeshAgent agent;
    
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;        
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
        agent.destination = stateMachine.transform.position - stateMachine.player.transform.position;
    }
}
