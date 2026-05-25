using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StateMachine<TInitialized> 
{
    private IState<TInitialized> _currentState;

    private readonly Dictionary<Type, IState<TInitialized>> _states;

    private bool _isUpdated = false;

    public StateMachine(params IState<TInitialized>[] states)
    {
        _states = new Dictionary<Type, IState<TInitialized>>(states.Length);

        foreach(var state in states)
        {
            _states.Add(state.GetType(), state);
        }
    }

    public void SwaitchState<TState>() where TState : IState<TInitialized>
    {
        ExitPrevState<TState>();

        GetNewState<TState>();

        EnterNewState<TState>();

        UpdateNewState<TState>();
    }

    private void ExitPrevState<TState>() where TState : IState<TInitialized>
    {
        if(_currentState is IExitState exitable)
        {
            exitable.OnExit();
        }
    }

    private void GetNewState<TState>() where TState : IState<TInitialized>
    {
        var newState = GetState<TState>();
        _currentState = newState;
    }

    private TState GetState<TState>() where TState : IState<TInitialized>
    {
        return (TState)_states[typeof(TState)];
    }

    private void EnterNewState<TState>() where TState : IState<TInitialized>
    {
        if (_currentState is IEnterState entarable)
        {
            entarable.OnEnter();
        }
    }

    private void UpdateNewState<TState>() where TState : IState<TInitialized>
    {
        if(_currentState is IUpdateState updated)
        {
            _isUpdated = true;
            StartUpdate(updated);
        }
        else
        {
            _isUpdated = false;
        }
    }

    private async void StartUpdate(IUpdateState updated)
    {
        while(_isUpdated)
        {
            updated.OnUpdate();
            await Task.Yield();
        }
    }
}
