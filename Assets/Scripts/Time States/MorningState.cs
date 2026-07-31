using UnityEngine;
public class MorningState : IState
{
    private readonly StatesSO settings;
    public MorningState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(manager, settings);
            manager.volumeController.ApplyVolumeSettings(true, manager.data.morningVolume);
        }
        else Debug.LogWarning("Missing *manager*"); 
    }

    public void Exit(Manager manager) {

        manager.lightController.ApplySunSettings(manager, settings);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.morningVolume);
    }
}