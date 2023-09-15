using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : NetworkTransform
{
    private State currentState;     //players current state

    public void SwitchState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public override void FixedUpdateNetwork()
    {
        if (Object.HasInputAuthority)
        {
            currentState?.Run();
        }        
    }
}

public abstract class State
{
    public abstract void Enter();
    public abstract void Run();
    public abstract void Exit();
}
