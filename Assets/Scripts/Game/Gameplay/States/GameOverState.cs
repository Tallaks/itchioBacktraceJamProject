using Game.Gameplay.Common;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;

namespace Game.Gameplay.States
{
  public class GameOverState : IState
  {
    private readonly Mediator _mediator;

    public GameOverState(Mediator mediator) => 
      _mediator = mediator;

    public void Enter()
    {
      foreach (MovingLeftObject movingLeftObject in Object.FindObjectsOfType<MovingLeftObject>())
        movingLeftObject.StopMoving();

      _mediator.SetActiveGameOverPanel(true);
    }

    public void Exit()
    {
    }
  }
}