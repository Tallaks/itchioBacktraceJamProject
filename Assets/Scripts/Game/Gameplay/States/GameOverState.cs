using Game.Gameplay.Common;
using Game.Gameplay.Player;
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
      foreach (Aid.Aid aid in Object.FindObjectsOfType<Aid.Aid>()) 
        Object.Destroy(aid.gameObject);

      foreach (MovingLeftObject movingLeftObject in Object.FindObjectsOfType<MovingLeftObject>())
        movingLeftObject.StopMoving();

      _mediator.SetActiveGameOverPanel(true);
    }

    public void Exit()
    {
      _mediator.SetActiveGameplayUi(false);
      _mediator.SetActiveGameOverPanel(false);
    }
  }
}