using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UI_Manager : MonoBehaviour
{
    public UIData uiData;

    public Manager manager;


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

        uiData.timeDropdown.ClearOptions();
        uiData.timeDropdown.AddOptions(timeOption);
        uiData.timeDropdown.onValueChanged.AddListener(OnTimeChanged);

        manager.GetComponent<Manager>();

    }
    public void OnWeatherChanged(int index) {


        switch (index)
        {
            case 0:
                manager.ChangeWeatherState(manager.defaultState);
                break;

            case 1:
                manager.ChangeWeatherState(manager.sunnyState);
                break;
                
            case 2:
                manager.ChangeWeatherState(manager.cloudyState);
                break;
                
            case 3:
                manager.ChangeWeatherState(manager.rainyState);
                break;

            case 4:
                manager.ChangeWeatherState(manager.snowyState);
                break;
        }
    }

    public void OnTimeChanged(int index)
    {


        switch (index)
        {
            case 0:
                manager.ChangeTimeState(manager.defaultTimeState);
                break;

            case 1:
                manager.ChangeTimeState(manager.morningState);
                break;

            case 2:
                manager.ChangeTimeState(manager.middayState);
                break;

            case 3:
                manager.ChangeWeatherState(manager.eveningState);
                break;

            case 4:
                manager.ChangeWeatherState(manager.nightState);
                break;
        }
    }
}