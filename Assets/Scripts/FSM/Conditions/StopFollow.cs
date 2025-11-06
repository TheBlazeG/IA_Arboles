using UnityEngine;
[CreateAssetMenu(fileName = "StopFollowCondition", menuName = "FSM/Conditions/StopFollowCondition")]
public class StopFollowCondition : Condition
{
    
    public override bool Check(StateMachine stateMachine)
    {
        if (Vector3.Distance(stateMachine.gameObject.transform.position,stateMachine.player.position)>2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

   
}
