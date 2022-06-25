using System.Collections;
using Game.Infrastructure;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay.States
{
  public class StartGameState : IState
  {
    private readonly CoroutineRunner _coroutineRunner;
    private readonly Mediator _mediator;

    public StartGameState(CoroutineRunner coroutineRunner, Mediator mediator)
    {
      _coroutineRunner = coroutineRunner;
      _mediator = mediator;
    }

    public void Enter()
    {
      _coroutineRunner.StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
      yield return loadOperation;

      new GameObject().AddComponent<GameStarter>();
      _mediator.SetActiveGameplayUi(true);
    }

    public void Exit()
    {
    }
  }
}