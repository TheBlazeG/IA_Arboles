using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "IdleState", menuName = "FSM/States/IdleState")]
public class Idleing : State
{
    NavMeshAgent agent;
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        agent.isStopped = true;
        
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
       
    }

    public override void Exit(StateMachine stateMachine) {
    agent.isStopped = false;
    }
}
