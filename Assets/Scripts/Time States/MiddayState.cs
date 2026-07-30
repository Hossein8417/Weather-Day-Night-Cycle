using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MiddayState : IState
{
    Vector3 stateRotation = new Vector3(90f, 200f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager)
    {
        if (manager.data != null)
        {
            manager.lightController.ApplySunSettings(80000, 4500, manager, stateRotation);
            manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.middayVolume);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager)
    {
        manager.lightController.ApplySunSettings(130000, 5000, manager, defaultRotation);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.middayVolume);
    }
}