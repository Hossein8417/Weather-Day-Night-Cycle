using UnityEngine;
public class SunnyState : IState
{
    Vector3 stateRotation = new Vector3(36f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {

        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(130000, 4449, manager, stateRotation);
            manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.sunnyVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
        manager.lightController.ApplySunSettings(130000, 5000, manager, defaultRotation);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.sunnyVolume);
    }
}