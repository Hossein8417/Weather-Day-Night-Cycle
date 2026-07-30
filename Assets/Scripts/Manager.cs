using UnityEngine;

public class Manager : MonoBehaviour
{
    public IState currentTime;

    public IState currentWeather;

    public DefaultTimeState defaultTimeState = new DefaultTimeState();
    public MorningState morningState = new MorningState();
    public MiddayState middayState = new MiddayState();
    public EveningState eveningState = new EveningState();
    public NightState nightState = new NightState();

    public DefaultState defaultState = new DefaultState();
    public SunnyState sunnyState = new SunnyState();
    public RainyState rainyState = new RainyState();
    public CloudyState cloudyState = new CloudyState();
    public SnowyState snowyState = new SnowyState();

    public Data data;

    public LightController lightController;
    public MaterialController materialController;
    public VolumeController volumeController;
    public ParticleController particleController;   

    private void Start()
    {
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
