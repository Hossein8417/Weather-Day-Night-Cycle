public interface ITimeState
{
    void Enter(TimeStateManager timeManager);
    void UpdateState(TimeStateManager timeManager);
    void SwitchWeather(TimeStateManager timeManager);
    void Exit(TimeStateManager timeManager);
}