using Game.Gameplay.Common;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Gameplay.States
{
  public class GameOverState : IState
  {
    public void Enter()
    {
      foreach (MovingLeftObject movingLeftObject in Object.FindObjectsOfType<MovingLeftObject>())
        movingLeftObject.StopMoving();
    }

    public void Exit()
    {
    }
  }
}