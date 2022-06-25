using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Game.Infrastructure.Services.StateMachine.States;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MainMenu
{
  public class MainPanel : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public Button StartGameButton;
    [Required, SceneObjectsOnly] public Button HighScoreButton;
    [Required, SceneObjectsOnly] public Button ExitButton;

    private StateMachine _stateMachine;

    private void Awake()
    {
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      
      StartGameButton.onClick.AddListener(StartGame);
      HighScoreButton.onClick.AddListener(OpenHighScore);
      ExitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
      _stateMachine.NextState(new StartGameState(AllServices.Instance.Resolve<CoroutineRunner>()));
    }

    public void OpenHighScore()
    {
      Debug.Log("High Score");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.ExecuteMenuItem("Edit/Play");
#endif
      Application.Quit();
    }
  }
}