using UnityEngine;
[CreateAssetMenu(fileName = "HealCondition", menuName = "FSM/Conditions/HealCondition")]
public class HealCondition : Condition
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override bool Check(StateMachine stateMachine)
    {
        stateMachine.blackboard.Get<GameObject>("knight").TryGetComponent<StateMachine>(out StateMachine knightState);
        if (knightState.health <50)
        {
            return true;
        }
        return false;
    }
}
