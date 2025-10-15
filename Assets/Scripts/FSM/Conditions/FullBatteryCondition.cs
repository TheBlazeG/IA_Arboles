using UnityEngine;
[CreateAssetMenu(fileName = "FullBatteryCondition", menuName = "FSM/Conditions/FullBatteryCondition")]
public class FullBatteryCondition : Condition
{
    float battery= 100;
    public override bool Check(StateMachine stateMachine)
    {
        battery+=5*Time.deltaTime;
        if(battery < 100 )
        {
            return false;
        }
        battery = 0;
        return true;

    }

   
}
