using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MiddayState : IState
{
    Vector3 stateRotation = new Vector3(90f, 180f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {

        manager.data.middayVolume.SetActive(true);
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 6500;
        SetLightIntensityInLux(100000, manager);

    }

    public void Exit(Manager manager) {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, manager);
        manager.data.middayVolume.SetActive(false);
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
