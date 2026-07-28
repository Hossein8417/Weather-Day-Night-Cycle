using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CloudyState : IState
{
    Vector3 stateRotation = new Vector3(40f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        if (manager.data != null)
        {
            manager.data.cloudyVolume.SetActive(true);
            manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
            manager.data.rainyParticle.gameObject.SetActive(false);
            manager.data.snowyParticle.gameObject.SetActive(false);
            manager.data.sun.colorTemperature = 11242;
            SetLightIntensityInLux(80000, manager);
        }
    }

    public void Exit(Manager manager) {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.sun.colorTemperature = 5000;
        manager.data.sun.luxAtDistance = 130000;
        manager.data.cloudyVolume.SetActive(false);
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