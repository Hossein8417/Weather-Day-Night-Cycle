using System;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Action OnTransitionFinished;

    [SerializeField]
    private float duration = 2f;

    [SerializeField]
    private Manager manager;

    private float timer;
    private bool isTransitioning;
    private bool hasFinished;
    private StatesSO currentStateSettings;
    private StatesSO targetStateSettings;

    public bool IsTransitioning => isTransitioning;

    public void StartTransition(StatesSO currentState, StatesSO targetState)
    {
        if (isTransitioning)
        {
            Debug.LogWarning("Transition already in progress");
            return;
        }

        if (currentState == null || targetState == null)
        {
            Debug.LogError("Cannot start transition with null settings");
            return;
        }

        if (manager == null)
        {
            Debug.LogError("Manager reference is null in Transition");
            return;
        }

        isTransitioning = true;
        hasFinished = false;
        timer = 0f;
        currentStateSettings = currentState;
        targetStateSettings = targetState;

        Debug.Log($"Transition started: {currentState.name} -> {targetState.name}");
    }

    private void Update()
    {
        if (!isTransitioning || hasFinished) return;

        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / duration);

        ApplyTransition(progress);

        if (progress >= 1f && !hasFinished)
        {
            hasFinished = true;
            FinishTransition();
        }
    }

    private void ApplyTransition(float progress)
    {
        if (currentStateSettings == null || targetStateSettings == null)
            return;

        try
        {
            Quaternion currentRotation = Quaternion.Euler(currentStateSettings.stateRotation);
            Quaternion targetRotation = Quaternion.Euler(targetStateSettings.stateRotation);
            Quaternion rotation = Quaternion.Lerp(currentRotation, targetRotation, progress);


            float lux = Mathf.Lerp(
                currentStateSettings.sunLuxAmount, 
                targetStateSettings.sunLuxAmount, 
                progress);


            float colorTemperature = Mathf.Lerp(
                currentStateSettings.sunColorTemperature,
                targetStateSettings.sunColorTemperature,
                progress
            );

            manager.lightController.ApplySunSettings(
                manager.data.sun,
                rotation,
                colorTemperature,
                lux
            );
        }
        catch (Exception e)
        {
            Debug.LogError($"Error applying transition: {e.Message}");
            isTransitioning = false;
            hasFinished = true;
        }
    }

    private void FinishTransition()
    {
        if (currentStateSettings == null || targetStateSettings == null)
        {
            isTransitioning = false;
            return;
        }

        try
        {
            
            manager.lightController.ApplySunSettings(
                manager.data.sun,
                Quaternion.Euler(targetStateSettings.stateRotation),
                targetStateSettings.sunColorTemperature,
                targetStateSettings.sunLuxAmount
            );

            isTransitioning = false;

            Debug.Log("Transition completed");

            OnTransitionFinished?.Invoke();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error finishing transition: {e.Message}");
            isTransitioning = false;
        }
    }

    public void CancelTransition()
    {
        if (!isTransitioning) return;

        isTransitioning = false;
        hasFinished = true;
        timer = 0f;
        Debug.Log("Transition cancelled");
    }
}