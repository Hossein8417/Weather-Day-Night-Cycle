using UnityEngine;
public class RainyState : IState
{
    Vector3 stateRotation = new Vector3(150f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        if (manager.data != null) {
            manager.lightController.ApplySunSettings(10000, 11242, manager, stateRotation);
            manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.rainyVolume);
            manager.particleController.ApplyParticleSettings(manager, manager.data.rainyParticle, true);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager)
    {
        manager.lightController.ApplySunSettings(130000, 5000, manager, defaultRotation);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.rainyVolume); ;
        manager.particleController.ApplyParticleSettings(manager, manager.data.rainyParticle, false);
    }
}