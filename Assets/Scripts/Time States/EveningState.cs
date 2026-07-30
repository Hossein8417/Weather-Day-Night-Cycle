using UnityEngine;
public class EveningState : IState
{
    Vector3 stateRotation = new Vector3(1.7f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);

    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(1511, 4500, manager, stateRotation);
            manager.lightController.ApplyLightSettings(800, 7641, manager, true);
            manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.eveningVolume);            
        }
        else Debug.LogWarning("Missing *manager*");        
    }
    public void Exit(Manager manager) {
        manager.lightController.ApplySunSettings(130000, 5000, manager, defaultRotation);
        manager.lightController.ApplyLightSettings(5000, 5000, manager, false);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.eveningVolume);
        
    }
}