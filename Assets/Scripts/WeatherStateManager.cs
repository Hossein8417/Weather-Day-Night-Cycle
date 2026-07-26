using UnityEngine;
public class WeatherStateManager : MonoBehaviour
{
    IWeatherState currentWeatherState;
    public DefaultState defaultState = new DefaultState();
    public SunnyState sunnyState = new SunnyState();
    public RainyState rainyState = new RainyState();
    public CloudyState cloudyState = new CloudyState();
    public SnowyState snowyState = new SnowyState();

    public Data data;
    
    void Start()
    {
        currentWeatherState = defaultState;

        currentWeatherState.Enter(this);
    }


    void Update()
    {
        currentWeatherState.UpdateState(this);
    }

    public void ChangeState(IWeatherState newState) {

        if (newState == currentWeatherState) return;

        currentWeatherState.Exit(this);
        
        currentWeatherState = newState;

        newState.Enter(this);

    }    
}