using System.Collections;
using Game.Infrastructure;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay.States
{
  public class RestartGameState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly CoroutineRunner _coroutineRunner;

    public RestartGameState(StateMachine stateMachine, CoroutineRunner coroutineRunner)
    {
      _stateMachine = stateMachine;
      _coroutineRunner = coroutineRunner;
    }
    
    public void Enter() => 
      _coroutineRunner.StartCoroutine(ReloadGameScene());

    public void Exit()
    {
    }

    private IEnumerator ReloadGameScene()
    {
      AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync("Game");
      yield return unloadOperation;
      
      _stateMachine.NextState(new StartGameState(_coroutineRunner, AllServices.Instance.Resolve<Mediator>()));
    }
  }
}