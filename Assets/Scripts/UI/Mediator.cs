using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Sirenix.OdinInspector;
using UI.MainMenu;
using UnityEngine;

namespace UI
{
  public class Mediator : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public MainPanel MainPanel;
    [Required, SceneObjectsOnly] public SidePanel SidePanel;
    
    private StateMachine _stateMachine;

    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
    }

    [Button, DisableInEditorMode] public void StartGame() => MainPanel.StartGame();
    [Button, DisableInEditorMode] public void OpenHighScore() => MainPanel.OpenHighScore();
    [Button, DisableInEditorMode] public void ExitGame() => MainPanel.ExitGame();
    [Button, DisableInEditorMode] public void ChangeMusicState() => SidePanel.ChangeMusicState();
  }
}