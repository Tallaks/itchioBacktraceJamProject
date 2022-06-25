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
    private readonly TargetFactory _targetFactory;

    public GameLoopState(CoroutineRunner coroutineRunner, ObstacleFactory obstacleFactory, TargetFactory targetFactory)
    {
      _coroutineRunner = coroutineRunner;
      _obstacleFactory = obstacleFactory;
      _targetFactory = targetFactory;
    }

    public void Enter()
    {
      Object.FindObjectOfType<Movement>().StartMoving();
      _coroutineRunner.StartCoroutine(SpawnObsatcles());
      _coroutineRunner.StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
      while (true)
      {
        float spawnDelay = Random.Range(2, 6);
        yield return new WaitForSeconds(spawnDelay);
        _targetFactory.Create();
      }
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