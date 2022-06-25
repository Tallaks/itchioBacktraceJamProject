using System.Collections;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Gameplay.Player
{
  public class GameLoopState : IState
  {
    private readonly CoroutineRunner _coroutineRunner;
    private readonly ObstacleFactory _obstacleFactory;

    public GameLoopState(CoroutineRunner coroutineRunner, ObstacleFactory obstacleFactory)
    {
      _coroutineRunner = coroutineRunner;
      _obstacleFactory = obstacleFactory;
    }

    public void Enter()
    {
      Object.FindObjectOfType<Movement>().StartFalling();
      _coroutineRunner.StartCoroutine(SpawnObsatcles());
    }

    private IEnumerator SpawnObsatcles()
    {
      while (true)
      {
        yield return new WaitForSeconds(3);
        _obstacleFactory.Create();
      }
    }

    public void Exit()
    {
    }
  }
}