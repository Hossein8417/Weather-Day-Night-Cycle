using UnityEngine;
public class Manager : MonoBehaviour
{
    public IState currentTime;

    public IState currentWeather;

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

    public Data data;

    public LightController lightController;
    public MaterialController materialController;
    public VolumeController volumeController;
    public ParticleController particleController;

    [SerializeField]
    private StatesRegistry statesRegistry;
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

        currentTime = defaultTimeState;
        currentTime.Enter(this);

        currentWeather = defaultState;
        currentWeather.Enter(this);
    }
    public void ChangeWeatherState(IState newState) {
        if (newState == currentWeather) return;

        currentWeather.Exit(this);

        currentWeather = newState;

        newState.Enter(this);
    }

    public void ChangeTimeState(IState newState) {

        if (newState == currentTime) return;

        currentTime.Exit(this);

        currentTime = newState;

        newState.Enter(this);
    }
}