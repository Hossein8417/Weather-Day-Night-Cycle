using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SnowyState : IState
{
    public void Enter(WeatherStateManager weatherManager) {
        weatherManager.data.snowyVolume.SetActive(true);
        weatherManager.data.ground.GetComponent<Renderer>().material = weatherManager.data.snowMaterial;
    }

    public void UpdateState(WeatherStateManager weatherManager) {
        weatherManager.data.rainyParticle.gameObject.SetActive(false);
        weatherManager.data.snowyParticle.gameObject.SetActive(true);
        weatherManager.data.snowyParticle.Play();
        weatherManager.data.sun.colorTemperature = 11000;
        SetLightIntensityInLux(71000, weatherManager);

        
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
            weatherManager.ChangeState(weatherManager.sunnyState);
        }
    }
    public void Exit(WeatherStateManager weatherManager) {
        weatherManager.data.ground.GetComponent<Renderer>().material = weatherManager.data.defaultMaterial;
        weatherManager.data.snowyParticle.Stop();
        weatherManager.data.snowyParticle.gameObject.SetActive(false);
        weatherManager.data.sun.colorTemperature = 5000;
        weatherManager.data.sun.luxAtDistance = 130000;
        weatherManager.data.snowyVolume.SetActive(false);
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