using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UI_Manager : MonoBehaviour
{
    public UIData uiData;

    public WeatherStateManager weatherManager;
    public TimeStateManager timeManager;


    List<TMP_Dropdown.OptionData> weatherOptions = new List<TMP_Dropdown.OptionData> {
        new TMP_Dropdown.OptionData("Default"),
        new TMP_Dropdown.OptionData("Sunny"),
        new TMP_Dropdown.OptionData("Cloudy"),
        new TMP_Dropdown.OptionData("Rainy"),
        new TMP_Dropdown.OptionData("Snowy"),
    };

    List<TMP_Dropdown.OptionData> timeOption = new List<TMP_Dropdown.OptionData> {
        new TMP_Dropdown.OptionData("Default"),
        new TMP_Dropdown.OptionData("Morning"),
        new TMP_Dropdown.OptionData("Midday"),
        new TMP_Dropdown.OptionData("Evening"),
        new TMP_Dropdown.OptionData("Night")
    };

    private void Start()
    {
        uiData.weatherDropdown.ClearOptions();
        uiData.weatherDropdown.AddOptions(weatherOptions);
        uiData.weatherDropdown.onValueChanged.AddListener(OnWeatherChanged);
        weatherManager.GetComponent<WeatherStateManager>();

        uiData.timeDropdown.ClearOptions();
        uiData.timeDropdown.AddOptions(timeOption);
        uiData.timeDropdown.onValueChanged.AddListener(OnTimeChanged);
        timeManager.GetComponent<TimeStateManager>();


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

    public void OnTimeChanged(int index)
    {


        switch (index)
        {
            case 0:
                timeManager.ChangeState(timeManager.defaultTimeState);
                break;

            case 1:
                timeManager.ChangeState(timeManager.morningState);
                break;

            case 2:
                timeManager.ChangeState(timeManager.middayState);
                break;

            case 3:
                timeManager.ChangeState(timeManager.eveningState);
                break;

            case 4:
                timeManager.ChangeState(timeManager.nightState);
                break;
        }
    }

}