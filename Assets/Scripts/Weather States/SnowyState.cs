using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
public class SnowyState : IState
{
    Vector3 stateRotation = new Vector3(60f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f); 
    public void Enter(Manager manager) {
        manager.data.ground.GetComponent<Renderer>().material = manager.data.snowMaterial;
        SetSunOn(manager);
        SetVolumeOn(manager);
        SetParticleOn(manager);
    }

    public void Exit(Manager manager) {
        manager.data.ground.GetComponent<Renderer>().material = manager.data.defaultMaterial;
        SetSunOff(manager);
        SetVolumeOff(manager);
        SetParticleOff(manager);
    }
    public void SetSunIntensityInLux(float luxValue, Manager manager)
    {
        if (manager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }
    }
    public void SetSunOn(Manager manager)
    {
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 11000;
        SetSunIntensityInLux(71000, manager);
    }
    public void SetSunOff(Manager manager)
    {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetSunIntensityInLux(130000, manager);
    }
    public void SetVolumeOn(Manager manager)
    {
        manager.data.snowyVolume.SetActive(true);
    }
    public void SetVolumeOff(Manager manager)
    {
        manager.data.snowyVolume.SetActive(false);
    }
    public void SetParticleOn(Manager manager)
    {
        manager.data.snowyParticle.gameObject.SetActive(true);
        manager.data.snowyParticle.Play();
    }
    public void SetParticleOff(Manager manager)
    {
        manager.data.snowyParticle.Stop();
        manager.data.snowyParticle.gameObject.SetActive(false);
    }

}