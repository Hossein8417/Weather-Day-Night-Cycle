using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SunnyState : IWeatherState
{
    Vector3 stateRotation = new Vector3(35f, 0f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(WeatherStateManager weatherManager) {

        if (weatherManager.data!= null)
        {
            weatherManager.data.sunnyVolume.SetActive(true);
        }
    }

    public void UpdateState(WeatherStateManager weatherManager) {
        weatherManager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
        weatherManager.data.rainyParticle.gameObject.SetActive(false);
        weatherManager.data.snowyParticle.gameObject.SetActive(false);
        weatherManager.data.sun.colorTemperature = 3828;
        SetLightIntensityInLux(130000, weatherManager);

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
            weatherManager.ChangeState(weatherManager.cloudyState);   
        }

    }

    public void Exit(WeatherStateManager weatherManager) {
        weatherManager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
        weatherManager.data.sun.colorTemperature = 5000;
        weatherManager.data.sun.luxAtDistance = 130000;
        weatherManager.data.sunnyVolume.SetActive(false);
    }
    void SetLightIntensityInLux(float luxValue, WeatherStateManager weatherManager) {
        if (weatherManager.data.sun.TryGetComponent<HDAdditionalLightData>(out var hdLightData))
        {
            LightUnit lux = UnityEngine.Rendering.LightUnit.Lux;
            hdLightData.SetIntensity(luxValue, lux);
        }

    }
}