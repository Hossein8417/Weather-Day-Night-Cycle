using UnityEngine;
public class EveningState : IState
{
    private readonly StatesSO settings;
    public EveningState(StatesSO settings)
    {
        this.settings = settings;
    }

    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplyLightSettings(
                manager.data.light,
                settings.lightColorTemperature,
                settings.lightLuxAmount,
                true);           
        }
        else Debug.LogWarning("Missing *manager*");        
    }
    public void Exit(Manager manager) {
        manager.lightController.ApplyLightSettings(
            manager.data.light,
            settings.lightColorTemperature, 
            settings.lightLuxAmount, 
            false);
    }
}