using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
    public void ApplySunSettings(Light sun, Quaternion rotation, float colorTemperature, float intensity) {
        sun.transform.rotation = rotation;
        sun.colorTemperature = colorTemperature;
        if (sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = LightUnit.Lux;
            hdLightData.SetIntensity(intensity, lux);
        }
    }
    public void ApplyLightSettings(Light light, float colorTemperature, float intensity, bool isEnable)
    {
        if (light.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = LightUnit.Lux;
            hdLightData.SetIntensity(intensity, lux);
        }
        light.gameObject.SetActive(isEnable);
        light.colorTemperature = colorTemperature;
    }
}