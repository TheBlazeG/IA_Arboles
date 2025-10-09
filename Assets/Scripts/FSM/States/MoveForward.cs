using UnityEngine;

[CreateAssetMenu(fileName ="MoveForwardState",menuName ="FSM/States/MoveForwardState")]
public class MoveForward : State
{
    public float speed = 2f;

    public override void FrameUpdate(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(stateMachine.transform.forward * speed * Time.deltaTime);
    }
}