using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private StatesRegistry statesRegistry;

    [SerializeField]
    private Transition transition;

    public Data data;

    private TimeStateMachine timeStateMachine;
    private WeatherStateMachine weatherStateMachine;

    public LightController lightController;
    public MaterialController materialController;
    public VolumeController volumeController;
    public ParticleController particleController;

    public DefaultTimeState defaultTimeState;
    public MorningState morningState;
    public MiddayState middayState;
    public EveningState eveningState;
    public NightState nightState;

    public DefaultState defaultState;
    public SunnyState sunnyState;
    public RainyState rainyState;
    public CloudyState cloudyState;
    public SnowyState snowyState;

    private void Start()
    {
        try
        {
            InitializeStates();
            InitializeStateMachines();
            SetupTransitionEvent();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Manager initialization failed: {e.Message}");
        }
    }

    private void InitializeStates()
    {
        defaultTimeState = new DefaultTimeState();
        morningState = new MorningState(statesRegistry.Get(TimeTypes.Morning));
        middayState = new MiddayState(statesRegistry.Get(TimeTypes.Midday));
        eveningState = new EveningState(statesRegistry.Get(TimeTypes.Evening));
        nightState = new NightState(statesRegistry.Get(TimeTypes.Night));

        defaultState = new DefaultState();
        sunnyState = new SunnyState();
        rainyState = new RainyState();
        cloudyState = new CloudyState();
        snowyState = new SnowyState();
    }

    private void InitializeStateMachines()
    {
        var initialTimeSettings = statesRegistry.Get(TimeTypes.Default);
        timeStateMachine = new TimeStateMachine(defaultTimeState, initialTimeSettings, this);
        weatherStateMachine = new WeatherStateMachine(defaultState, this);
    }

    private void SetupTransitionEvent()
    {
        if (transition != null)
        {
            transition.OnTransitionFinished += FinishTimeTransition;
        }
        else
        {
            Debug.LogWarning("Transition component is not assigned!");
        }
    }

    private void OnDestroy()
    {
        if (transition != null)
        {
            transition.OnTransitionFinished -= FinishTimeTransition;
        }
    }

    public void ChangeWeatherState(IState newState)
    {
        if (weatherStateMachine == null)
        {
            Debug.LogError("WeatherStateMachine is not initialized!");
            return;
        }
        weatherStateMachine.ChangeState(newState);
    }

    public void ChangeTimeState(IState newState, StatesSO targetSettings)
    {
        if (timeStateMachine == null)
        {
            Debug.LogError("TimeStateMachine is not initialized!");
            return;
        }

        if (timeStateMachine.IsTransitioning)
        {
            Debug.LogWarning("Transition already in progress");
            return;
        }

        var currentSettings = timeStateMachine.CurrentSettings;

        if (ReferenceEquals(currentSettings, targetSettings) ||
            (currentSettings != null && targetSettings != null &&
             currentSettings.name == targetSettings.name))
        {
            Debug.Log("Target state is already active");
            return;
        }

        Debug.Log($"Starting transition from: {currentSettings?.name ?? "null"} to: {targetSettings?.name ?? "null"}");

        timeStateMachine.PrepareTransition(newState, targetSettings);
        transition?.StartTransition(currentSettings, targetSettings);
    }

    public void FinishTimeTransition()
    {
        if (timeStateMachine == null)
        {
            Debug.LogError("TimeStateMachine is not initialized!");
            return;
        }

        timeStateMachine.CompleteTransition();
        Debug.Log($"Time state changed to: {timeStateMachine.CurrentSettings?.name ?? "null"}");
    }

    public IState GetCurrentTimeState() => timeStateMachine?.CurrentState;
    public StatesSO GetCurrentTimeSettings() => timeStateMachine?.CurrentSettings;
    public IState GetCurrentWeatherState() => weatherStateMachine?.CurrentState;
    public bool IsTimeTransitioning() => timeStateMachine?.IsTransitioning ?? false;
}