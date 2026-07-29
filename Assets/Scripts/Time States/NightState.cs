using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class NightState : IState
{
    Vector3 stateRotation = new Vector3(35f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            SetSunOn(manager);
            SetVolumeOn(manager);
            SetLightOn(manager);
        }
        else Debug.LogWarning("Missing *manager*");
    }
    public void Exit(Manager manager) {
        SetSunOff(manager);
        SetVolumeOff(manager);
        SetLightOff(manager);
    }
    void SetSuntIntensityInLux(float luxValue, Manager manager)
    {
        if (manager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }

    }
    public void SetSunOn(Manager manager) {

        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 20000;
        SetSuntIntensityInLux(0.5f, manager);
    }
    public void SetSunOff(Manager manager)
    {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetSuntIntensityInLux(130000, manager);

    }
    public void SetVolumeOn(Manager manager)
    {
        manager.data.nightVolume.SetActive(true);
    }
    public void SetVolumeOff(Manager manager)
    {
        manager.data.nightVolume.SetActive(false);
    }
    public void SetLightOn(Manager manager) {
        manager.data.light.gameObject.SetActive(true);
    }
    public void SetLightOff(Manager manager)
    {
        manager.data.light.gameObject.SetActive(false);
    }
}
