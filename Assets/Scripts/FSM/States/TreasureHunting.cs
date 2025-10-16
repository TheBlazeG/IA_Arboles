using UnityEngine;

public class TreasureHunting : State
{
    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);
        stateMachine.agent.destination= stateMachine.route[stateMachine.currentWaypoint].position;
        stateMachine.blackboard.Set("PlayerHealth", 100);

    }
    public override void FrameUpdate(StateMachine stateMachine)
    {

        if (Vector3.Distance(stateMachine.gameObject.transform.position, stateMachine.route[stateMachine.currentWaypoint].position)<1)
        {
            Destroy(stateMachine.route[stateMachine.currentWaypoint].gameObject);
            stateMachine.currentWaypoint = stateMachine.currentWaypoint < stateMachine.route.Length-1 ? stateMachine.currentWaypoint + 1 : 0;
            stateMachine.agent.destination = stateMachine.route[stateMachine.currentWaypoint].position;
        }
    }
}
