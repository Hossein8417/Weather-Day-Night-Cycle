using UnityEngine;

public class SnowyState : IState
{
    public void Enter(WeatherStateManager weatherManager) {
        Debug.Log("Enter Snowy State");
    }

    public void UpdateState(WeatherStateManager weatherManager) { }

    public void Exit(WeatherStateManager weatherManager) {
        Debug.Log("Exit Snowy State");
    }
}
