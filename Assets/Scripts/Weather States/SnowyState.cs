using UnityEngine;
public class SnowyState : IState
{
    private readonly StatesSO settings;
    public SnowyState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager) {
        manager.materialController.ApplyMaterialSettings(manager.data.ground, manager.data.snowMaterial);
        manager.lightController.ApplySunSettings(manager.data.sun, settings);
        manager.volumeController.ApplyVolumeSettings(true, manager.data.snowyVolume);
        manager.particleController.ApplyParticleSettings(manager.data.snowyParticle, true);
    }

    public void Exit(Manager manager) {
        manager.materialController.ApplyMaterialSettings(manager.data.ground, manager.data.defaultMaterial);
        manager.lightController.ApplySunSettings(manager.data.sun, settings);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.snowyVolume);
        manager.particleController.ApplyParticleSettings(manager.data.snowyParticle, false);
    }
}