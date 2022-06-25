using Game.Gameplay.Player;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Infrastructure
{
  public class GameStarter : MonoBehaviour
  {
    private StateMachine _stateMachine;
    private CoroutineRunner _coroutineRunner;
    private ObstacleFactory _obstacleFactory;
    private TargetFactory _targetFactory;

    private void Awake()
    {
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      _coroutineRunner = AllServices.Instance.Resolve<CoroutineRunner>();
      _obstacleFactory = AllServices.Instance.Resolve<ObstacleFactory>();
      _targetFactory = AllServices.Instance.Resolve<TargetFactory>();
    }

    private void Update()
    {
      if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
        StartGame();
    }

    private void StartGame()
    {
      _stateMachine.NextState(new GameLoopState(_coroutineRunner, _obstacleFactory, _targetFactory));
      Destroy(gameObject);
    }
  }
}