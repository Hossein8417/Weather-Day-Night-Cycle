using UnityEngine;

public class TimeStateManager : MonoBehaviour
{
    public ITimeState currentTime;

    public DefaultTimeState defaultTimeState = new DefaultTimeState();
    public MorningState morningState = new MorningState();
    public MiddayState middayState = new MiddayState();
    public EveningState eveningState = new EveningState();
    public NightState nightState = new NightState();

    public Data data;

    private void Start()
    {
        currentTime = defaultTimeState;
        currentTime.Enter(this);
    }

    public void ChangeState(ITimeState newState) {
        if (newState == currentTime) return;

        currentTime.Exit(this);

        currentTime = newState;

        newState.Enter(this);
    }
}