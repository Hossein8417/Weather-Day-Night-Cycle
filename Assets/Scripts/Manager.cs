using UnityEngine;
public class Manager : MonoBehaviour
{
    [SerializeField]
    private StatesRegistry statesRegistry;

    [SerializeField]
    private Transition transition;

    public Data data;

    public IState currentTime;
    public IState newState;

    public IState currentWeather;

    private StatesSO currentTimeSettings;
    private StatesSO targetStateSettings;

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

    public LightController lightController;
    public MaterialController materialController;
    public VolumeController volumeController;
    public ParticleController particleController;

    private void Start()
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

        //---------------------------

        currentTimeSettings = statesRegistry.Get(TimeTypes.Default);

        //---------------------------

        currentTime = defaultTimeState;
        currentTime.Enter(this);

        currentWeather = defaultState;                
        currentWeather.Enter(this);

        transition.OnTransitionFinished += FinishStateChange;
    }
    public void ChangeWeatherState(IState newState)
    {
        if (newState == currentWeather) return;

        currentWeather.Exit(this);

        currentWeather = newState;

        newState.Enter(this);
    }

    public void ChangeTimeState(IState newState, StatesSO targetStateSettings)
    {
        if (this.newState == currentTime) return;
        if (this.targetStateSettings == currentTimeSettings) return;

        this.newState = newState;
        this.targetStateSettings = targetStateSettings;

        Debug.Log($"Current: {currentTimeSettings.name}");
        Debug.Log($"Target : {this.targetStateSettings.name}");

        transition.StartTransition(currentTimeSettings, this.targetStateSettings);
    }

    public void FinishStateChange() { 

        currentTime.Exit(this);
        currentTime = newState;
        currentTimeSettings = targetStateSettings;
        currentTime.Enter(this);
        Debug.Log(currentTimeSettings.name);
    }
}