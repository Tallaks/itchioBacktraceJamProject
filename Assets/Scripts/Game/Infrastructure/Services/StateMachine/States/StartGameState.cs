using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Infrastructure.Services.StateMachine.States
{
  public class StartGameState : IState
  {
    private readonly CoroutineRunner _coroutineRunner;

    public StartGameState(CoroutineRunner coroutineRunner) => 
      _coroutineRunner = coroutineRunner;

    public void Enter()
    {
      _coroutineRunner.StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
      yield return loadOperation;
    }

    public void Exit()
    {
    }
  }
}