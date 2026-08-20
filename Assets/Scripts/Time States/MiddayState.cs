using UnityEngine;

public class MiddayState : IState
{
    private readonly StatesSO settings;

    public MiddayState(StatesSO settings)
    {
        this.settings = settings;
    }

    public void Enter(Manager manager)
    {
        if (manager.data.light != null && settings != null)
        {
            manager.lightController.ApplyLightSettings(
                manager.data.light,
                settings.lightColorTemperature,
                settings.lightLuxAmount,
                true
            );

        }
        else
        {
            Debug.LogWarning("Missing Data reference or settings in Manager");
        }
    }

    public void Exit(Manager manager)
    {
        if (manager.data.light != null && settings != null)
        {
            manager.lightController.ApplyLightSettings(
                manager.data.light,
                settings.lightColorTemperature,
                settings.lightLuxAmount,
                false
            );
        }
    }
}