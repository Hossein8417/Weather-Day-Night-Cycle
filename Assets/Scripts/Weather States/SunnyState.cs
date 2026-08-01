using UnityEngine;
public class SunnyState : IState
{
    public void Enter(Manager manager) {

        if (manager.data != null)
        {
            manager.volumeController.ApplyVolumeSettings(true, manager.data.sunnyVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
        manager.volumeController.ApplyVolumeSettings(false, manager.data.sunnyVolume);
    }
}