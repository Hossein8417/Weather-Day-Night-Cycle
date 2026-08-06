using UnityEngine;
public class MiddayState : IState
{
    private readonly StatesSO settings;
    public MiddayState(StatesSO settings)
    {
        this.settings = settings;
    }
    public void Enter(Manager manager)
    {
    }

    public void Exit(Manager manager)
    {
    }
}