using System;
using UnityEngine;

public class TimeStateMachine
{
    private IState currentState;
    private StatesSO currentSettings;
    private readonly Manager manager;

    private IState pendingState;
    private StatesSO pendingSettings;
    private bool isTransitioning;

    public IState CurrentState => currentState;
    public StatesSO CurrentSettings => currentSettings;
    public bool IsTransitioning => isTransitioning;

    public TimeStateMachine(IState initialState, StatesSO initialSettings, Manager manager)
    {
        //this.currentState = initialState ?? throw new ArgumentNullException(nameof(initialState));
        //this.currentSettings = initialSettings ?? throw new ArgumentNullException(nameof(initialSettings));
        //this.manager = manager ?? throw new ArgumentNullException(nameof(manager));
        this.isTransitioning = false;
        //?
        currentState.Enter(manager);
    }

    public void PrepareTransition(IState newState, StatesSO newSettings)
    {
        if (newState == null)
        {
            Debug.LogError("Cannot prepare transition with null state");
            return;
        }

        if (newSettings == null)
        {
            Debug.LogError("Cannot prepare transition with null settings");
            return;
        }

        pendingState = newState;
        pendingSettings = newSettings;
        isTransitioning = true;
    }

    public void CompleteTransition()
    {
        if (!isTransitioning || pendingState == null || currentState == null)
        {
            Debug.LogWarning("Invalid transition state - cannot complete");
            return;
        }

        try
        {
            currentState.Exit(manager);

            currentState = pendingState;
            currentSettings = pendingSettings;

            currentState?.Enter(manager);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error during state transition: {e.Message}");
        }
        finally
        {
            // Reset
            pendingState = null;
            pendingSettings = null;
            isTransitioning = false;
        }
    }

    public void CancelTransition()
    {
        if (!isTransitioning) return;

        pendingState = null;
        pendingSettings = null;
        isTransitioning = false;
        Debug.Log("Transition cancelled");
    }
}