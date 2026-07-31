using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
    public void ApplySunSettings(Manager manager, StatesSO settings) {
        manager.data.sun.transform.rotation = Quaternion.Euler(settings.stateRotation);
        manager.data.sun.colorTemperature = settings.sunColorTemperature;
        if (manager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = LightUnit.Lux;
            hdLightData.SetIntensity(settings.sunLuxAmount, lux);
        }
    }
    public void ApplyLightSettings(Manager manager, StatesSO settings, bool isEnable)
    {
        if (manager.data.light.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = LightUnit.Lux;
            hdLightData.SetIntensity(settings.lightLuxAmount, lux);
        }
        manager.data.light.gameObject.SetActive(isEnable);
        manager.data.light.colorTemperature = settings.lightColorTemperature;
    }
}