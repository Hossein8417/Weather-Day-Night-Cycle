using UnityEngine;

public class CloudyState : IState
{
    public void Enter(WeatherStateManager weatherManager) {
        Debug.Log("Enter Cloudy State");
    }

    public void UpdateState(WeatherStateManager weatherManager) { }

    public void Exit(WeatherStateManager weatherManager) {
        Debug.Log("Enter Cloudy State");
    }
}
