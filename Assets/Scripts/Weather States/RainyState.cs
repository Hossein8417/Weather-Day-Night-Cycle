using UnityEngine;
public class RainyState : IState
{
    public void Enter(Manager manager) {
        if (manager.data != null) {
            manager.volumeController.ApplyVolumeSettings(true, manager.data.rainyVolume);
            manager.particleController.ApplyParticleSettings(manager.data.rainyParticle, true);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager)
    {
        manager.volumeController.ApplyVolumeSettings(false, manager.data.rainyVolume); ;
        manager.particleController.ApplyParticleSettings(manager.data.rainyParticle, false);
    }
}