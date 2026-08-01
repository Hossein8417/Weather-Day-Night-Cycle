using UnityEngine;
public class SnowyState : IState
{
    public void Enter(Manager manager) {
        manager.materialController.ApplyMaterialSettings(manager.data.ground, manager.data.snowMaterial);
        manager.volumeController.ApplyVolumeSettings(true, manager.data.snowyVolume);
        manager.particleController.ApplyParticleSettings(manager.data.snowyParticle, true);
    }

    public void Exit(Manager manager) {
        manager.materialController.ApplyMaterialSettings(manager.data.ground, manager.data.defaultMaterial);
        manager.volumeController.ApplyVolumeSettings(false, manager.data.snowyVolume);
        manager.particleController.ApplyParticleSettings(manager.data.snowyParticle, false);
    }
}