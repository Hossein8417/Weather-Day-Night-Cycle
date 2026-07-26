using UnityEngine;
public class WeatherStateManager : MonoBehaviour
{


    IState currentState;

    public SunnyState sunnyState = new SunnyState();
    public RainyState rainyState = new RainyState();
    public CloudyState cloudyState = new CloudyState();
    public SnowyState snowyState = new SnowyState();

    public WeatherData data;
    
    void Start()
    {
        currentState = sunnyState;

        currentState.Enter(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState) { 

        currentState = newState;

        newState.Enter(this);

    }
}