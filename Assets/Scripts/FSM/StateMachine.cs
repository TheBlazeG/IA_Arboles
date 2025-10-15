using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }
    [SerializeField] State initialState;
    public Transform[] route;
    public int currentWaypoint = 0;
    public NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        ChangeState(initialState);
    }


    public void ChangeState(State state)
    {
        if (CurrentState == state || state == null) { return; }

        if (CurrentState != null)
        {
            CurrentState.Exit(this);
        }
        CurrentState = state;
        CurrentState.Enter(this);
    }

    void Update()
    {
        CurrentState.FrameUpdate(this);
        CurrentState.CheckTransitions(this);
    }

    void FixedUpdate()
    {
        CurrentState.PhysicUpdate();
    }
}
