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
        morningState = new MorningState(statesRegistry.assets[Types.Morning]);
        middayState = new MiddayState(statesRegistry.assets[Types.Midday]);
        eveningState = new EveningState(statesRegistry.assets[Types.Evening]);
        nightState = new NightState(statesRegistry.assets[Types.Night]);
        defaultState = new DefaultState();
        sunnyState = new SunnyState(statesRegistry.assets[Types.Sunny]);
        rainyState = new RainyState(statesRegistry.assets[Types.Rainy]);
        cloudyState = new CloudyState(statesRegistry.assets[Types.Cloudy]);
        snowyState = new SnowyState(statesRegistry.assets[Types.Snowy]);

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