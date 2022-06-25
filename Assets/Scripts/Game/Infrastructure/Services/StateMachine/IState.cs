namespace Game.Infrastructure.Services.StateMachine
{
  public interface IState
  {
    void Enter();
    void Exit();
  }
}