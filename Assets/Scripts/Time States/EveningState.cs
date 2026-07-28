using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class EveningState : IState
{
    Vector3 stateRotation = new Vector3(1.7f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);

    public void Enter(Manager manager) {
        manager.data.eveningVolume.SetActive(true);
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.sun.colorTemperature = 4500;
        SetLightIntensityInLux(3369, manager);
        manager.data.light.gameObject.SetActive(true);
        //set lump values 

    }
    public void Exit(Manager manager) {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        SetLightIntensityInLux(130000, manager);
        manager.data.light.gameObject.SetActive(false);
        manager.data.eveningVolume.SetActive(false);
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