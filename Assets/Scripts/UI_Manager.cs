using System;
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

    private readonly Dictionary<int, Action> weatherActions = new Dictionary<int, Action>();
    private readonly Dictionary<int, Action> timeActions = new Dictionary<int, Action>();

    private void Start()
    {
        InitializeDropdowns();
        InitializeActions();
    }

    private void InitializeDropdowns()
    {
        var weatherOptions = new List<TMP_Dropdown.OptionData>
        {
            new TMP_Dropdown.OptionData("Default"),
            new TMP_Dropdown.OptionData("Sunny"),
            new TMP_Dropdown.OptionData("Cloudy"),
            new TMP_Dropdown.OptionData("Rainy"),
            new TMP_Dropdown.OptionData("Snowy")
        };

        uiData.weatherDropdown.ClearOptions();
        uiData.weatherDropdown.AddOptions(weatherOptions);
        uiData.weatherDropdown.onValueChanged.AddListener(OnWeatherChanged);

        var timeOptions = new List<TMP_Dropdown.OptionData>
        {
            new TMP_Dropdown.OptionData("Default"),
            new TMP_Dropdown.OptionData("Morning"),
            new TMP_Dropdown.OptionData("Midday"),
            new TMP_Dropdown.OptionData("Evening"),
            new TMP_Dropdown.OptionData("Night")
        };

        uiData.timeDropdown.ClearOptions();
        uiData.timeDropdown.AddOptions(timeOptions);
        uiData.timeDropdown.onValueChanged.AddListener(OnTimeChanged);
    }

    private void InitializeActions()
    {
        if (manager == null)
        {
            Debug.LogError("Manager reference is null in UI_Manager");
            return;
        }

        weatherActions[0] = () => manager.ChangeWeatherState(manager.defaultState);
        weatherActions[1] = () => manager.ChangeWeatherState(manager.sunnyState);
        weatherActions[2] = () => manager.ChangeWeatherState(manager.cloudyState);
        weatherActions[3] = () => manager.ChangeWeatherState(manager.rainyState);
        weatherActions[4] = () => manager.ChangeWeatherState(manager.snowyState);

        timeActions[0] = () => manager.ChangeTimeState(manager.defaultTimeState, registry.Get(TimeTypes.Default));
        timeActions[1] = () => manager.ChangeTimeState(manager.morningState, registry.Get(TimeTypes.Morning));
        timeActions[2] = () => manager.ChangeTimeState(manager.middayState, registry.Get(TimeTypes.Midday));
        timeActions[3] = () => manager.ChangeTimeState(manager.eveningState, registry.Get(TimeTypes.Evening));
        timeActions[4] = () => manager.ChangeTimeState(manager.nightState, registry.Get(TimeTypes.Night));
    }

    public void OnWeatherChanged(int index)
    {
        if (weatherActions.TryGetValue(index, out var action))
        {
            action?.Invoke();
            Debug.Log($"Weather changed to: {uiData.weatherDropdown.options[index].text}");
        }
        else
        {
            Debug.LogWarning($"Invalid weather index: {index}");
        }
    }

    public void OnTimeChanged(int index)
    {
        if (timeActions.TryGetValue(index, out var action))
        {
            action?.Invoke();
            Debug.Log($"Time changed to: {uiData.timeDropdown.options[index].text}");
        }
        else
        {
            Debug.LogWarning($"Invalid time index: {index}");
        }
    }

    public void UpdateWeatherDropdown(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < uiData.weatherDropdown.options.Count)
        {
            uiData.weatherDropdown.value = selectedIndex;
        }
    }

    public void UpdateTimeDropdown(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < uiData.timeDropdown.options.Count)
        {
            uiData.timeDropdown.value = selectedIndex;
        }
    }

    private void OnDestroy()
    {
        if (uiData.weatherDropdown != null)
            uiData.weatherDropdown.onValueChanged.RemoveListener(OnWeatherChanged);

        if (uiData.timeDropdown != null)
            uiData.timeDropdown.onValueChanged.RemoveListener(OnTimeChanged);
    }
}