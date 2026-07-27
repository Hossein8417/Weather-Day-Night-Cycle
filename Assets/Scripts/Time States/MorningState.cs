using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MorningState : ITimeState
{
    Vector3 stateRotation = new Vector3(30f, 120f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);


    public void Enter(TimeStateManager timeManager) {

        timeManager.data.morningVolume.SetActive(true);
        timeManager.data.sun.transform.rotation =  Quaternion.Euler(stateRotation);
        timeManager.data.sun.colorTemperature = 5500;
        SetLightIntensityInLux(50000, timeManager);
    }

    public void Exit(TimeStateManager timeManager) {
        timeManager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        timeManager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, timeManager);
        timeManager.data.morningVolume.SetActive(false);
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