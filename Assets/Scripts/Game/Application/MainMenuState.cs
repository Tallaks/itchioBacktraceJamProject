using System.Collections;
using Game.Application.Sound;
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
    private AudioMediator _audio;

    public MainMenuState(CoroutineRunner runner) => 
      _runner = runner;

    public void Enter()
    {
      RegisterMediators();

      _audio.RestartMusic();
      if (SceneManager.GetSceneByName("Game").isLoaded) 
        _runner.StartCoroutine(UnloadGameScene());
    }

    public void Exit()
    {
    }

    private void RegisterMediators()
    {
      AllServices.Instance.RegisterService(Object.FindObjectOfType<Mediator>());
      AllServices.Instance.RegisterService(Object.FindObjectOfType<AudioMediator>());
      _mediator = AllServices.Instance.Resolve<Mediator>();
      _audio = AllServices.Instance.Resolve<AudioMediator>();
    }

    private IEnumerator UnloadGameScene()
    {
      AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync("Game");
      yield return unloadOperation;
      
      _mediator.SetActiveMainMenuUi(true);
      _mediator.SetActiveGameplayUi(false);
      _mediator.SetActiveGameOverPanel(false);
    }
  }
}