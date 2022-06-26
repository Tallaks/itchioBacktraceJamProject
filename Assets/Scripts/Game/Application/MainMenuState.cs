using System.Collections;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Application
{
  public class MainMenuState : IState
  {
    private readonly CoroutineRunner _runner;
    private Mediator _mediator;

    public MainMenuState(CoroutineRunner runner) => 
      _runner = runner;

    public void Enter()
    {
      AllServices.Instance.RegisterService(Object.FindObjectOfType<Mediator>());
      _mediator = AllServices.Instance.Resolve<Mediator>();

      if (SceneManager.GetSceneByName("Game").isLoaded) 
        _runner.StartCoroutine(UnloadGameScene());
    }

    private IEnumerator UnloadGameScene()
    {
      AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync("Game");
      yield return unloadOperation;
      
      _mediator.SetActiveMainMenuUi(true);
      _mediator.SetActiveGameplayUi(false);
      _mediator.SetActiveGameOverPanel(false);
    }

    public void Exit()
    {
    }
  }
}