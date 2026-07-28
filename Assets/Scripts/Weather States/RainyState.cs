using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class RainyState : IState
{
    Vector3 stateRotation = new Vector3(150f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager) {
        manager.data.rainyVolume.SetActive(true);
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.rainyParticle.gameObject.SetActive(true);
        manager.data.snowyParticle.gameObject.SetActive(false);
        manager.data.rainyParticle.Play();
        manager.data.sun.colorTemperature = 11242;
        SetLightIntensityInLux(10000, manager);
        manager.data.light.gameObject.SetActive(true);
    }

    public void Exit(Manager manager) {
        manager.data.rainyParticle.Stop();
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.rainyParticle.gameObject.SetActive(false);
        manager.data.sun.colorTemperature = 5000;
        manager.data.sun.luxAtDistance = 130000;
        manager.data.light.gameObject.SetActive(false);
        manager.data.rainyVolume.SetActive(false);
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