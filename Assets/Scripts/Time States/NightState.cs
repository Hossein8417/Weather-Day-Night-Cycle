using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class NightState : ITimeState
{
    Vector3 stateRotation = new Vector3(35f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(TimeStateManager timeManager) {
        timeManager.data.nightVolume.SetActive(true);
        timeManager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        timeManager.data.sun.colorTemperature = 20000;
        SetLightIntensityInLux(0.5f, timeManager);
        timeManager.data.light.gameObject.SetActive(true);
    }

    public void Exit(TimeStateManager timeManager) {
        timeManager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        timeManager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, timeManager);
        timeManager.data.light.gameObject.SetActive(false);
        timeManager.data.nightVolume.SetActive(false);
    }
    void SetLightIntensityInLux(float luxValue, TimeStateManager timeManager)
    {
        if (timeManager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }

    }
}
