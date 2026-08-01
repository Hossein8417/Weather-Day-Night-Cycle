using UnityEngine;
public class CloudyState : IState
{
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.volumeController.ApplyVolumeSettings(true, manager.data.cloudyVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager) {
        manager.volumeController.ApplyVolumeSettings(false, manager.data.cloudyVolume);
    }
}