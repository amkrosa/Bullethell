using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public void ChangeState(IState newState)
    {
        if (CurrentState != null) CurrentState.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }
    public void Update()
    {
        if (CurrentState != null) CurrentState.OnExecute();
    }
}

public interface IState
{
    void OnEnter();
    void OnExecute();
    void OnExit();
}
