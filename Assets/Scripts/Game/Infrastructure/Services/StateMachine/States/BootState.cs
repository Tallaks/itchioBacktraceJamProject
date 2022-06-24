using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Infrastructure.Services.StateMachine.States
{
  public class BootState : IState
  {
    private readonly CoroutineRunner _runner;

    public BootState(CoroutineRunner runner) => 
      _runner = runner;

    public void Enter() => 
      _runner.StartCoroutine(LoadMenuScene());

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