using UnityEngine;
public class CloudyState : IState
{
    Vector3 stateRotation = new Vector3(40f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(80000, 7081, manager, stateRotation);
            manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.cloudyVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager) {
        manager.lightController.ApplySunSettings(130000, 5000, manager, defaultRotation);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.cloudyVolume);
    }
}