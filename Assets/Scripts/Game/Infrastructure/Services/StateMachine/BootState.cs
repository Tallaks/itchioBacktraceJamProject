using System.Collections;
using DG.Tweening;
using Game.Application;
using Game.Infrastructure.Services.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Infrastructure.Services.StateMachine
{
  public class BootState : IState
  {
    private readonly CoroutineRunner _runner;

    public BootState(CoroutineRunner runner) => 
      _runner = runner;

    public void Enter()
    {
      DOTween.Init();
      RegisterServices();
      _runner.StartCoroutine(LoadMenuScene());
    }

    private static void RegisterServices()
    {
      AllServices.Instance.RegisterService(new ObstacleFactory());
      AllServices.Instance.RegisterService(new TargetFactory());
      AllServices.Instance.RegisterService(new AidFactory());
    }

    private IEnumerator LoadMenuScene()
    {
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
      yield return loadOperation;
      
      AllServices.Instance.Resolve<StateMachine>().NextState(new MainMenuState());
    }

    public void Exit()
    {
    }
  }
}