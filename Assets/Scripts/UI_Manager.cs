using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private UIData uiData;

    [SerializeField]
    private Manager manager;

    [SerializeField]
    private StatesRegistry registry;

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
        Debug.Log("UI");
        switch (index)
        {
            case 0:
                manager.ChangeTimeState(manager.defaultTimeState, registry.Get(TimeTypes.Default));
                break;

            case 1:
                manager.ChangeTimeState(manager.morningState, registry.Get(TimeTypes.Morning));
                break;

            case 2:
                manager.ChangeTimeState(manager.middayState, registry.Get(TimeTypes.Midday));
                break;

            case 3:
                manager.ChangeTimeState(manager.eveningState, registry.Get(TimeTypes.Evening));
                break;

            case 4:
                manager.ChangeTimeState(manager.nightState, registry.Get(TimeTypes.Night));
                break;
        }
    }
}