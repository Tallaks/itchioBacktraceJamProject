using System.Collections;
using Game.Gameplay.Player;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Gameplay.States
{
  public class GameLoopState : IState
  {
    private readonly CoroutineRunner _coroutineRunner;
    private readonly ObstacleFactory _obstacleFactory;
    private readonly TargetFactory _targetFactory;
    
    private Coroutine _obstaclesSpawnRoutine;
    private Coroutine _targetSpawnRoutine;

    public GameLoopState(CoroutineRunner coroutineRunner, ObstacleFactory obstacleFactory, TargetFactory targetFactory)
    {
      _coroutineRunner = coroutineRunner;
      _obstacleFactory = obstacleFactory;
      _targetFactory = targetFactory;
    }

    public void Enter()
    {
      Object.FindObjectOfType<Movement>().StartMoving();
      _obstaclesSpawnRoutine = _coroutineRunner.StartCoroutine(SpawnObstacles());
      _targetSpawnRoutine = _coroutineRunner.StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
      while (true)
      {
        float spawnDelay = Random.Range(5, 10);
        yield return new WaitForSeconds(spawnDelay);
        _targetFactory.Create();
      }
    }

    private IEnumerator SpawnObstacles()
    {
      while (true)
      {
        yield return new WaitForSeconds(3);
        _obstacleFactory.Create();
      }
    }

    public void Exit()
    {
      _coroutineRunner.StopCoroutine(_obstaclesSpawnRoutine);
      _coroutineRunner.StopCoroutine(_targetSpawnRoutine);
    }
  }
}