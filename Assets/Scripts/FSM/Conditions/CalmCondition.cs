using UnityEngine;
[CreateAssetMenu(fileName = "CalmCondition", menuName = "FSM/Conditions/CalmCondition")]
public class CalmCondition : Condition
{
   
    public override bool Check(StateMachine stateMachine)
    {
        if (Vector3.Distance(stateMachine.gameObject.transform.position, stateMachine.player.position) < 2)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

   
}
