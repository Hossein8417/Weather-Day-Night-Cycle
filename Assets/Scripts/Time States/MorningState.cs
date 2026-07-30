using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MorningState : IState
{
    Vector3 stateRotation = new Vector3(30f, 120f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(100000, 5500, manager , stateRotation);
            manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.morningVolume);
        }
        else Debug.LogWarning("Missing *manager*"); 
    }

    public void Exit(Manager manager) {

        manager.lightController.ApplySunSettings(130000, 5500, manager, defaultRotation);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.morningVolume);
    }
}