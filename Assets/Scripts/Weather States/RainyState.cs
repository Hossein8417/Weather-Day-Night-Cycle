using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class RainyState : IWeatherState
{
    Vector3 stateRotation = new Vector3(150f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(WeatherStateManager weatherManager) {
        weatherManager.data.rainyVolume.SetActive(true);
        weatherManager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        weatherManager.data.rainyParticle.gameObject.SetActive(true);
        weatherManager.data.snowyParticle.gameObject.SetActive(false);
        weatherManager.data.rainyParticle.Play();
        weatherManager.data.sun.colorTemperature = 11242;
        SetLightIntensityInLux(10000, weatherManager);
        weatherManager.data.light.gameObject.SetActive(true);
    }

    public void Exit(WeatherStateManager weatherManager) {
        weatherManager.data.rainyParticle.Stop();
        weatherManager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        weatherManager.data.rainyParticle.gameObject.SetActive(false);
        weatherManager.data.sun.colorTemperature = 5000;
        weatherManager.data.sun.luxAtDistance = 130000;
        weatherManager.data.light.gameObject.SetActive(false);
        weatherManager.data.rainyVolume.SetActive(false);
    }
    void SetLightIntensityInLux(float luxValue, WeatherStateManager weatherManager)
    {
        if (weatherManager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }

    }
}