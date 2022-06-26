using System.Collections;
using Game.Application.GameScore;
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
      Score.Reset();
      _coroutineRunner.StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
      yield return loadOperation;

      GameStarter gameStarter = 
        Object.FindObjectOfType<GameStarter>() != null ? 
        Object.FindObjectOfType<GameStarter>() : 
        new GameObject().AddComponent<GameStarter>();

      CheckTutorial();
      _mediator.SetActiveGameplayUi(true);
    }

    private static void CheckTutorial()
    {
      if (PlayerPrefs.GetString("Tutorial", "true") == "true")
      {
        var prefab = Resources.Load<GameObject>("Prefabs/Gameplay/Tutorial");
        Object.Instantiate(prefab, new Vector3(2,0,0), Quaternion.identity);
        PlayerPrefs.SetString("Tutorial", "false");
        PlayerPrefs.Save();
      }
    }

    public void Exit()
    {
    }
  }
}