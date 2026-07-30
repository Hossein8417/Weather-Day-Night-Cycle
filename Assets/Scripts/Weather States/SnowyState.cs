using UnityEngine;
public class SnowyState : IState
{
    Vector3 stateRotation = new Vector3(60f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f); 
    public void Enter(Manager manager) {
        manager.materialController.ApplyMaterialSettings(manager, manager.data.snowMaterial);
        manager.lightController.ApplySunSettings(71000, 11000, manager, stateRotation);
        manager.volumeController.ApplyVolumeSettings(manager, true, manager.data.snowyVolume);
        manager.particleController.ApplyParticleSettings(manager, manager.data.snowyParticle, true);
    }

    public void Exit(Manager manager) {
        manager.materialController.ApplyMaterialSettings(manager, manager.data.defaultMaterial);
        manager.lightController.ApplySunSettings(130000, 5000, manager, defaultRotation);
        manager.volumeController.ApplyVolumeSettings(manager, false, manager.data.snowyVolume);
        manager.particleController.ApplyParticleSettings(manager, manager.data.snowyParticle, false);
    }
}