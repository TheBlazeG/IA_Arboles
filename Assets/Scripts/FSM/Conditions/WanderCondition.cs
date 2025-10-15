using UnityEngine;
[CreateAssetMenu(fileName = "WanderCondition", menuName = "FSM/Conditions/WanderCondition")]
public class WanderCondition : Condition
{
    float timer;
    public override bool Check(StateMachine stateMachine)
    {
        if (timer < 5) 
        {
            timer += 1 * Time.deltaTime;
            return false;
        }
        else 
        {
            stateMachine.agent.isStopped = false;
            timer = 0;
            return true;
        }
        
    }

   
}
