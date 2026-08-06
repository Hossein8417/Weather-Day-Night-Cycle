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

    private StatesSO currentStateSettings;
    private StatesSO targetStateSettings;

    public void StartTransition(StatesSO currentState, StatesSO targetState) {

        isTransitioning = true;
        timer = 0f;
        currentStateSettings = currentState;
        targetStateSettings = targetState;
        Debug.Log($"Start: {currentState.name}");
        Debug.Log($"End: {targetState.name}");

    }

    private void Update() {
        if(!isTransitioning) return;

        timer += Time.deltaTime;

        float progress = Mathf.Clamp01(timer / duration);

        ApplyTransition(progress);

        if (progress >= 1f)
        {
            FinishTransition(manager);
            
        }

    }
    private void ApplyTransition(float progress) {

        Quaternion rotation = Quaternion.Lerp(Quaternion.Euler(currentStateSettings.stateRotation),
            Quaternion.Euler(targetStateSettings.stateRotation), progress);

        float lux = Mathf.Lerp(currentStateSettings.sunLuxAmount, targetStateSettings.sunLuxAmount, progress);

        float colorTemperature = Mathf.Lerp(currentStateSettings.sunColorTemperature, targetStateSettings.sunColorTemperature, progress);

        manager.lightController.ApplySunSettings(manager.data.sun, rotation, colorTemperature, lux);

    }

    private void FinishTransition(Manager manager) {

        Debug.Log("Finish");

        OnTransitionFinished?.Invoke();

        manager.lightController.ApplySunSettings(manager.data.sun, Quaternion.Euler(targetStateSettings.stateRotation),
            targetStateSettings.sunColorTemperature, targetStateSettings.sunLuxAmount);

        isTransitioning = false;
        Debug.Log(isTransitioning);

    }
}