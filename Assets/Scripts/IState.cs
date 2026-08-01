public interface IState
{
    void Enter(Manager manager);
    void Exit(Manager manager);
}