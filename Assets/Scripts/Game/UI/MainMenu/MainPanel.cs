using Game.Gameplay.States;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MainMenu
{
  public class MainPanel : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public Button StartGameButton;
    [Required, SceneObjectsOnly] public Button ExitButton;

    private StateMachine _stateMachine;
    private CoroutineRunner _coroutineRunner;

    private void Awake()
    {
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      _coroutineRunner = AllServices.Instance.Resolve<CoroutineRunner>();

      StartGameButton.onClick.AddListener(StartGame);
      ExitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
      _stateMachine.NextState(new StartGameState(_coroutineRunner, AllServices.Instance.Resolve<Mediator>()));
      SetActiveMainPanel(false);
    }

    public void SetActiveMainPanel(bool state) =>
      gameObject.SetActive(state);

    public void ExitGame()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.ExecuteMenuItem("Edit/Play");
#endif
      UnityEngine.Application.Quit();
    }
  }
}