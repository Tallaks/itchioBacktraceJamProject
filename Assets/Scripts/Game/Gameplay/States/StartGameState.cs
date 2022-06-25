using System.Collections;
using Game.Infrastructure;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay.States
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

      new GameObject().AddComponent<GameStarter>();
    }

    public void Exit()
    {
    }
  }
}