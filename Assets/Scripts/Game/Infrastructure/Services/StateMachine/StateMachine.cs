using System;
using Game.Infrastructure.Services.StateMachine.States;

namespace Game.Infrastructure.Services.StateMachine
{
  public class StateMachine : IService
  {
    public StateMachine(IState startState) => 
      NextState(startState);

    public IState CurrentState { get; private set; }

    public void NextState(IState nextState)
    {
      if (nextState == null)
        throw new NullReferenceException("No new state set");
      
      CurrentState?.Exit();
      CurrentState = nextState;
      nextState.Enter();
    }
  }
}