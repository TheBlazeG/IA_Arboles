using UnityEngine;

[CreateAssetMenu(fileName = "AttackingState", menuName = "FSM/States/AttackingState")]
public class Attacking : State
{
    float timer;
    public override void Enter(StateMachine stateMachine)
    {
        stateMachine.agent.enabled=false;
        timer = 0;
    }
    public override void FrameUpdate(StateMachine stateMachine)
    {
        base.FrameUpdate(stateMachine);
        stateMachine.gameObject.transform.Rotate(0,180*Time.deltaTime,0);
        timer += 1 * Time.deltaTime;
        if (timer>4)
        {
            timer = 0;
            stateMachine.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb);
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
            stateMachine.player.TryGetComponent<PlayerMovement>(out PlayerMovement player);
            player.health -= 20;
        }
    }
    public override void Exit(StateMachine stateMachine) 
    {
        stateMachine.agent.enabled = true;

    }
}
