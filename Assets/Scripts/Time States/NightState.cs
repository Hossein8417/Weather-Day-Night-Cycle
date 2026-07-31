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
            manager.lightController.ApplySunSettings(manager, settings);
            manager.lightController.ApplyLightSettings(manager, settings, true);
            manager.volumeController.ApplyVolumeSettings(true, manager.data.nightVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
        manager.lightController.ApplySunSettings(manager, settings);
        manager.lightController.ApplyLightSettings(manager, settings, false);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.nightVolume);
    }
}