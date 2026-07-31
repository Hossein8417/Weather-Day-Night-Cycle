using UnityEngine;
public class CloudyState : IState
{
    private readonly StatesSO settings;
    public CloudyState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(manager.data.sun, settings);
            manager.volumeController.ApplyVolumeSettings(true, manager.data.cloudyVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager) {
        manager.lightController.ApplySunSettings(manager.data.sun, settings);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.cloudyVolume);
    }
}