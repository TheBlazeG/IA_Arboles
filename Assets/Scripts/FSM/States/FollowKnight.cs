using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "FollowKnightState", menuName = "FSM/States/FollowKnightState")]
public class FollowKnight : State
{
    NavMeshAgent agent;
    
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        stateMachine.blackboard.Set<GameObject>("knight", GameObject.Find("Knight"));
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
        agent.destination = stateMachine.blackboard.Get<GameObject>("knight").transform.position;
    }
}
