using UnityEngine;
[CreateAssetMenu(fileName = "BatteryCondition", menuName = "FSM/Conditions/BatteryCondition")]
public class BatteryCondition : Condition
{
    public float battery= 100;
    bool hasRecharged = true;
    public override bool Check(StateMachine stateMachine)
    {   


        battery-=1*Time.deltaTime;
        if(battery < 0 )
        {
            battery = 100;
            return true;
        }
        return false;

    }

   
}
