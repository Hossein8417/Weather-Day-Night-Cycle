public interface IWeatherState
{
    void Enter(WeatherStateManager weatherManager);

    void Exit(WeatherStateManager weatherManager);
}