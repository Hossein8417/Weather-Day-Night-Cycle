using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MorningState : IState
{
    Vector3 stateRotation = new Vector3(30f, 120f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);


    public void Enter(Manager manager) {

        manager.data.morningVolume.SetActive(true);
        manager.data.sun.transform.rotation =  Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 5500;
        SetLightIntensityInLux(50000, manager);
    }

    public void Exit(Manager manager) {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, manager);
        manager.data.morningVolume.SetActive(false);
    }

    void SetLightIntensityInLux(float luxValue, Manager manager)
    {
        if (manager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }

    }
}