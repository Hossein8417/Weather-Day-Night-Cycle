using System;
using UnityEngine;

public class WeatherStateMachine
{
    private IState currentState;
    private readonly Manager manager;

    public IState CurrentState => currentState;

    public WeatherStateMachine(IState initialState, Manager manager)
    {
        //this.currentState = initialState ?? throw new ArgumentNullException(nameof(initialState));
        //this.manager = manager ?? throw new ArgumentNullException(nameof(manager));
        //?
        currentState.Enter(manager);
    }

    public void ChangeState(IState newState)
    {
        if (newState == null)
        {
            Debug.LogError("Cannot change to null state");
            return;
        }

        if (ReferenceEquals(newState, currentState))
            return;

        try
        {

            currentState?.Exit(manager);

            currentState = newState;

            currentState?.Enter(manager);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error during weather state change: {e.Message}");
        }
    }
}
