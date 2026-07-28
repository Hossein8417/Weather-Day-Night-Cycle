using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class NightState : IState
{
    Vector3 stateRotation = new Vector3(35f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        manager.data.nightVolume.SetActive(true);
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 20000;
        SetLightIntensityInLux(0.5f, manager);
        manager.data.light.gameObject.SetActive(true);
    }

    public void Exit(Manager manager) {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, manager);
        manager.data.light.gameObject.SetActive(false);
        manager.data.nightVolume.SetActive(false);
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
