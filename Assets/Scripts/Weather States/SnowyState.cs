using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SnowyState : IState
{
    Vector3 stateRotation = new Vector3(60f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f); 
    public void Enter(Manager manager) {
        manager.data.snowyVolume.SetActive(true);
        manager.data.ground.GetComponent<Renderer>().material = manager.data.snowMaterial;
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        manager.data.rainyParticle.gameObject.SetActive(false);
        manager.data.snowyParticle.gameObject.SetActive(true);
        manager.data.snowyParticle.Play();
        manager.data.sun.colorTemperature = 11000;
        SetLightIntensityInLux(71000, manager);
    }

    public void Exit(Manager manager) {
        manager.data.ground.GetComponent<Renderer>().material = manager.data.defaultMaterial;
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        manager.data.snowyParticle.Stop();
        manager.data.snowyParticle.gameObject.SetActive(false);
        manager.data.sun.colorTemperature = 5000;
        manager.data.sun.luxAtDistance = 130000;
        manager.data.snowyVolume.SetActive(false);
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