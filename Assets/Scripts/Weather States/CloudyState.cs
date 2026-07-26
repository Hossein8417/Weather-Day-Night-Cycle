using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CloudyState : IState
{
    public void Enter(WeatherStateManager weatherManager) {
        if (weatherManager.data != null)
        {
            weatherManager.data.cloudyVolume.SetActive(true);
        }
    }

    public void UpdateState(WeatherStateManager weatherManager) {
        weatherManager.data.rainyParticle.gameObject.SetActive(false);
        weatherManager.data.snowyParticle.gameObject.SetActive(false);
        weatherManager.data.sun.colorTemperature = 11242;
        SetLightIntensityInLux(80000, weatherManager);
        //wind sound 
        //grass movement
        //tree movement
        //turm on/turn off light
        SwitchWeather(weatherManager);
    }

    public void SwitchWeather(WeatherStateManager weatherManager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Exit(weatherManager);
            weatherManager.ChangeState(weatherManager.rainyState);   
        }

    }

    public void Exit(WeatherStateManager weatherManager) {
        weatherManager.data.sun.colorTemperature = 5000;
        weatherManager.data.sun.luxAtDistance = 130000;
        weatherManager.data.cloudyVolume.SetActive(false);
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