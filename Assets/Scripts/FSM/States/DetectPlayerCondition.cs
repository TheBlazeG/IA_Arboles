using UnityEngine;
[CreateAssetMenu(fileName = "DetectPlayerCondition", menuName = "FSM/Conditions/DetectPlayerCondition")]
public class DetectPlayerCondition : Condition
{
    public float checkDistance = 1.5f;
    public LayerMask playerMask;
    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, stateMachine.transform.forward);

        return Physics.Raycast(ray, checkDistance,playerMask);
    }

   
}
