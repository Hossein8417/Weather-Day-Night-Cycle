using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
    public void ApplySunSettings(Light sun, StatesSO settings) {
        sun.transform.rotation = Quaternion.Euler(settings.stateRotation);
        sun.colorTemperature = settings.sunColorTemperature;
        if (sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = LightUnit.Lux;
            hdLightData.SetIntensity(settings.sunLuxAmount, lux);
        }
    }
    public void ApplyLightSettings(Light light, StatesSO settings, bool isEnable)
    {
        if (light.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = LightUnit.Lux;
            hdLightData.SetIntensity(settings.lightLuxAmount, lux);
        }
        light.gameObject.SetActive(isEnable);
        light.colorTemperature = settings.lightColorTemperature;
    }
}