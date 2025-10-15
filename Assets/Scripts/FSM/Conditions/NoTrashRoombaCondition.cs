using UnityEngine;
[CreateAssetMenu(fileName = "NoTrashRoombaCondition", menuName = "FSM/Conditions/NoTrashRoombaCondition")]
public class NoTrashRoombaCondition : Condition
{
    float timer;
    public override bool Check(StateMachine stateMachine)
    {
        foreach (var item in stateMachine.route)
        {
            if (item.gameObject.activeSelf)
            {
                return false;
            }
        }
       
        
            return true;
        
    }

   
}
