using UnityEngine;
[CreateAssetMenu(fileName = "InvestigateCondition", menuName = "FSM/Conditions/InvestigateCondition")]
public class InvestigateCondition : Condition
{
    public float checkDistance = 1.5f;
    public LayerMask interestMask;
    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, Vector3.right);
        Ray ray2 = new Ray(stateMachine.transform.position, Vector3.left);

        if(Physics.Raycast(ray,out RaycastHit hit, checkDistance, interestMask))
        {
            hit.transform.gameObject.layer = 0;
            return true;
        }
        else if (Physics.Raycast(ray2, out RaycastHit hit2, checkDistance, interestMask))
        {
            hit.transform.gameObject.layer = 0;
            return true;
        }
        else
            return false;

    }

   
}
