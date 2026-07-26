public interface IWeatherState
{
    void Enter(WeatherStateManager weatherManager);
    void UpdateState(WeatherStateManager weatherManager);
    void SwitchWeather(WeatherStateManager weatherManager);
    void Exit(WeatherStateManager weatherManager);
}