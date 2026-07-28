using UnityEngine;
public class DefaultState : IState
{
    Vector3 stateRotation = new Vector3(0f, -29f, 0f);
    Vector3 defaultRotation = new Vector3(0f, 0f, 0f);
    public void Enter(Manager manager)
    {
        manager.data.sun.transform.rotation = Quaternion.Euler(stateRotation);
    }
    public void Exit(Manager manager)
    {
        manager.data.sun.transform.rotation = Quaternion.Euler(defaultRotation);
    }
}