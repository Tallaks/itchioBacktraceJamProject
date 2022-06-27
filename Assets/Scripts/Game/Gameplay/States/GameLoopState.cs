using System.Collections;
using Game.Application.GameScore;
using Game.Gameplay.Player;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay.States
{
  public class GameLoopState : IState
  {
    private Coroutine _obstaclesSpawnRoutine;
    private Coroutine _targetSpawnRoutine;
    
    private readonly CoroutineRunner _coroutineRunner;
    private readonly TargetFactory _targetFactory;
    private readonly ObstacleFactory _obstacleFactory;
    private readonly Mediator _mediator;
    
    public GameLoopState()
    {
      _coroutineRunner = AllServices.Instance.Resolve<CoroutineRunner>();
      _targetFactory = AllServices.Instance.Resolve<TargetFactory>();
      _obstacleFactory = AllServices.Instance.Resolve<ObstacleFactory>();
      _mediator = AllServices.Instance.Resolve<Mediator>();
    }

    public void Enter()
    {
      Object.FindObjectOfType<Movement>().StartMoving();
      
      StartSpawning();
    }

    public void Exit()
    {
      _coroutineRunner.StopCoroutine(_obstaclesSpawnRoutine);
      _coroutineRunner.StopCoroutine(_targetSpawnRoutine);
    }

    private void StartSpawning()
    {
      _obstacleFactory.SetParent(GameObject.Find("Obstacles"));
      _targetFactory.SetParent(GameObject.Find("Targets"));
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
      float time = 0;
      float minDelay = 3;
      float maxDelay = 7;
      while (true)
      {
        float currentDelay = Random.Range(minDelay, maxDelay);
        time += currentDelay;
        yield return new WaitForSeconds(currentDelay);
        _obstacleFactory.Create().transform.localScale = GetRandomScale(time);
        minDelay = Mathf.Clamp(3 - time/120f, 0.5f, 3f);
        maxDelay = Mathf.Clamp(3 - time/120f, 0.5f, 3f);
      }
    }

    private Vector3 GetRandomScale(float time)
    {
      float modifier = Random.Range(1, 1 + time / 120f);
      return Vector3.one * modifier;
    }
  }
}