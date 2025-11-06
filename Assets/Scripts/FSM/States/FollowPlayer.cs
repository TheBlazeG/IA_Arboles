using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "FollowPlayerState", menuName = "FSM/States/FollowPlayerState")]
public class FollowPlayer : State
{
    NavMeshAgent agent;
    
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
        agent.destination = stateMachine.player.transform.position;
    }
}
