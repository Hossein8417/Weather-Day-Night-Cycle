using UnityEngine;

public class DefaultTimeState : ITimeState
{
    public void Enter(TimeStateManager timeManager) { }
    public void UpdateState(TimeStateManager timeManager) { }
    public void SwitchWeather(TimeStateManager timeManager  ) { }
    public void Exit(TimeStateManager timeManager) { }
}
