using UnityEngine;
[CreateAssetMenu(fileName = "FleeCondition", menuName = "FSM/Conditions/FleeCondition")]
public class FleeCondition : Condition
{
    float timer;
    
    public override bool Check(StateMachine stateMachine)
    {
        if (Vector3.Distance(stateMachine.gameObject.transform.position,stateMachine.player.position)<2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

   
}
