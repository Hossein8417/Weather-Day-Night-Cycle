using UnityEngine;
public class WeatherStateManager : MonoBehaviour
{
    IState currentState;
    public DefaultState defaultState = new DefaultState();
    public SunnyState sunnyState = new SunnyState();
    public RainyState rainyState = new RainyState();
    public CloudyState cloudyState = new CloudyState();
    public SnowyState snowyState = new SnowyState();

    public WeatherData data;
    
    void Start()
    {
        currentState = defaultState;

        currentState.Enter(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState) {

        if (newState == currentState) return;

        currentState.Exit(this);
        
        currentState = newState;

        newState.Enter(this);

    }    
}