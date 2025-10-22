using UnityEngine;

[CreateAssetMenu(fileName = "FollowKnightCondition", menuName = "FSM/Conditions/FollowKnightCondition")]
public class FollowKnightCondition : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        stateMachine.blackboard.Get<GameObject>("knight").TryGetComponent<StateMachine>(out StateMachine knightState);
        if (knightState.health > 50)
        {
            return true;
        }
        return false;
    }
}
