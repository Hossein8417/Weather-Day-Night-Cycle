using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UI_Manager : MonoBehaviour
{
    public UIData uiData;

    public WeatherStateManager weatherManager;

    List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData> {
        new TMP_Dropdown.OptionData("Default"),
        new TMP_Dropdown.OptionData("Sunny"),
        new TMP_Dropdown.OptionData("Cloudy"),
        new TMP_Dropdown.OptionData("Rainy"),
        new TMP_Dropdown.OptionData("Snowy"),
    };

    private void Start()
    {
        uiData.weatherDropdown.ClearOptions();
        uiData.weatherDropdown.AddOptions(options);
        uiData.weatherDropdown.onValueChanged.AddListener(OnWeatherChanged);
        weatherManager.GetComponent<WeatherStateManager>();

    }
    public void OnWeatherChanged(int index) {


        switch (index)
        {
            case 0:
                weatherManager.ChangeState(weatherManager.defaultState);
                break;

            case 1:
                weatherManager.ChangeState(weatherManager.sunnyState);
                break;
                
            case 2:
                weatherManager.ChangeState(weatherManager.cloudyState);
                break;
                
            case 3:
                weatherManager.ChangeState(weatherManager.rainyState);
                break;

            case 4:
                weatherManager.ChangeState(weatherManager.snowyState);
                break;
        }
    }
}