using UnityEngine;

public class SunnyState : IState
{
    public void Enter(WeatherStateManager weatherManager) {

        if (weatherManager.data.sunnyWeatherData!= null)
        {
            Debug.Log("Sun");
            

        }
        

    }

    public void UpdateState(WeatherStateManager weatherManager) { }

    public void Exit(WeatherStateManager weatherManager) {
        Debug.Log("Exit Sunny State");
    }
}