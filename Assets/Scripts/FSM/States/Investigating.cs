using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "InvestigatingState", menuName = "FSM/States/InvestigatingState")]
public class investigating : State
{
    NavMeshAgent agent;
    public override void Enter(StateMachine stateMachine)
    {
        agent = stateMachine.agent;
        agent.isStopped = true;

    }

    public override void FrameUpdate(StateMachine stateMachine) 
    {
        stateMachine.gameObject.transform.Rotate(0, 5, 0);
    }


}
