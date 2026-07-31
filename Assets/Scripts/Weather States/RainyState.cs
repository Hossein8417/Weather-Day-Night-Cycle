using UnityEngine;
public class RainyState : IState
{
    private readonly StatesSO settings;
    public RainyState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager) {
        if (manager.data != null) {
            manager.lightController.ApplySunSettings(manager.data.sun, settings);
            manager.volumeController.ApplyVolumeSettings(true, manager.data.rainyVolume);
            manager.particleController.ApplyParticleSettings(manager.data.rainyParticle, true);
        }
        else Debug.LogWarning("Missing *manager*");
    }

    public void Exit(Manager manager)
    {
        manager.lightController.ApplySunSettings(manager.data.sun, settings);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.rainyVolume); ;
        manager.particleController.ApplyParticleSettings(manager.data.rainyParticle, false);
    }
}