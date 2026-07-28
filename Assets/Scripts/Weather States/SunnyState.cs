using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SunnyState : IState
{
    Vector3 stateRotation = new Vector3(36f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {

        if (manager.data != null)
        {
            SetSunOn(manager);
            SetVolumeOn(manager);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
       SetSunOff(manager);
        SetVolumeOff(manager);
    }
    public void SetLightIntensityInLux(float luxValue, Manager manager) {
        if (manager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }
    }
    public void SetSunOn(Manager manager) {
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 4449;
        SetLightIntensityInLux(130000, manager);
    }
    public void SetSunOff(Manager manager)
    {        
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, manager);
    }
    public void SetVolumeOn(Manager manager) {
        manager.data.sunnyVolume.SetActive(true);
    }
    public void SetVolumeOff(Manager manager)
    {
        manager.data.sunnyVolume.SetActive(false);
    }
}