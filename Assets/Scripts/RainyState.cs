using UnityEngine;

public class RainyState : IState
{
    public void Enter(WeatherStateManager weatherManager) {
        Debug.Log("Enter Rainy State");
    }

    public void UpdateState(WeatherStateManager weatherManager) { }

    public void Exit(WeatherStateManager weatherManager) {
        Debug.Log("Exit Rainy State");
    }
}
