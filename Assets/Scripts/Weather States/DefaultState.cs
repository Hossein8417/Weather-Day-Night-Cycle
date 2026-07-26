using UnityEngine;
public class DefaultState : IWeatherState
{
    public void Enter(WeatherStateManager weatherManager) { }

    public void UpdateState(WeatherStateManager weatherManager) { }

    public void SwitchWeather(WeatherStateManager weatherManager) { }
    
    public void Exit(WeatherStateManager weatherManager) { }
}