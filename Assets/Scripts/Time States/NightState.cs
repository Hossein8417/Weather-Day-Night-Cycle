using UnityEngine;
public class NightState : IState
{
    private readonly StatesSO settings;
    public NightState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplyLightSettings(manager.data.light, settings.lightColorTemperature, settings.lightLuxAmount, true);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
        manager.lightController.ApplyLightSettings(manager.data.light, settings.lightColorTemperature, settings.lightLuxAmount, false);
    }
}