using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
    public void ApplySunSettings(float luxAmount, float sunColorTemperature, Manager manager, Vector3 rotate) {
        manager.data.sun.transform.rotation = Quaternion.Euler(rotate);
        manager.data.sun.colorTemperature = sunColorTemperature;
        if (manager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxAmount, lux);
        }
    }
    public void ApplyLightSettings(float luxAmount, float lightColorTemperature, Manager manager, bool isEnable)
    {
        if (manager.data.light.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxAmount, lux);
        }
        manager.data.light.gameObject.SetActive(isEnable);
        manager.data.light.colorTemperature = lightColorTemperature;
    }
}