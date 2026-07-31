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
            manager.lightController.ApplySunSettings(manager.data.sun, settings);
            manager.lightController.ApplyLightSettings(manager.data.light, settings, true);
            manager.volumeController.ApplyVolumeSettings(true, manager.data.nightVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
        manager.lightController.ApplySunSettings(manager.data.sun, settings);
        manager.lightController.ApplyLightSettings(manager.data.light, settings, false);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.nightVolume);
    }
}