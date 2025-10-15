using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "RechargingState", menuName = "FSM/States/RechargingState")]
public class Recharging : State
{
    NavMeshAgent agent;
    Transform rechargeStation;
    
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        rechargeStation= GameObject.Find("RechargeStation").transform;
        agent.destination = rechargeStation.position;
    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {

    }
}
