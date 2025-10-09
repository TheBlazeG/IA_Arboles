using UnityEngine;
[CreateAssetMenu(fileName = "OIIAEingState", menuName = "FSM/States/OIIAEingState")]
public class OIIAEing : State
{
    public float rotateSpeed = 1;
    public override void FrameUpdate(StateMachine stateMachine) 
    {
        stateMachine.transform.Rotate(new Vector3(rotateSpeed,0,0));
    }
}
