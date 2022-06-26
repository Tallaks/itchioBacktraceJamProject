using Game.Infrastructure.Services;
using Game.UI.Gameplay;
using Game.UI.MainMenu;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
  public class Mediator : MonoBehaviour, IService
  {
    [Required, SceneObjectsOnly] public MainPanel MainPanel;
    [Required, SceneObjectsOnly] public SidePanel SidePanel;
    [Required, SceneObjectsOnly] public CurrentScore Score;
    [Required, SceneObjectsOnly] public GameOverPanel GameOverPanel;
    
    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      DontDestroyOnLoad(FindObjectOfType<EventSystem>());
    }
    
    [Button, GUIColor(0, 1, 0), DisableInEditorMode] public void StartGame() => MainPanel.StartGame();
    [Button, GUIColor(1, 1, 0), DisableInEditorMode] public void OpenHighScore() => MainPanel.OpenHighScore();
    [Button, GUIColor(1, 1, 0), DisableInEditorMode] public void SetActiveMainMenuUi(bool state) => MainPanel.SetActiveMainPanel(state);
    [Button, GUIColor(1, 0, 1), DisableInEditorMode] public void ChangeMusicState() => SidePanel.ChangeMusicState();
    [Button, GUIColor(0, 1, 1), DisableInEditorMode] public void SetActiveGameplayUi(bool state) => Score.gameObject.SetActive(state);
    [Button, GUIColor(0, 1, 1), DisableInEditorMode] public void ResetScore() => Score.Reset();
    [Button, GUIColor(0, 1, 1), DisableInEditorMode] public void AddScore(int value) => Score.AddScore(value);
    [Button, GUIColor(0, 1, 1), DisableInEditorMode] public void SetActiveGameOverPanel(bool state) => GameOverPanel.SetActivePanel(state);
    [Button, GUIColor(0, 1, 1), DisableInEditorMode] public void ReturnToMenu() => GameOverPanel.RetutnToMainMenu();
    [Button, GUIColor(0, 1, 1), DisableInEditorMode] public void RestartGame() => GameOverPanel.RestartGame();
    [Button, GUIColor(1, 0, 0), DisableInEditorMode] public void ExitGame() => MainPanel.ExitGame();
  }
}