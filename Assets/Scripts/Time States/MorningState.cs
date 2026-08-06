using UnityEngine;
public class MorningState : IState
{
    private readonly StatesSO settings;
    public MorningState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager) {

    }

    public void Exit(Manager manager) {

    }
}