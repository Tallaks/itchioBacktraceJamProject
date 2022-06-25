using Game.UI.MainMenu;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
  public class Mediator : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public MainPanel MainPanel;
    [Required, SceneObjectsOnly] public SidePanel SidePanel;
    
    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      DontDestroyOnLoad(FindObjectOfType<EventSystem>());
    }
    
    [Button, GUIColor(0, 1, 0), DisableInEditorMode] public void StartGame() => MainPanel.StartGame();
    [Button, DisableInEditorMode] public void OpenHighScore() => MainPanel.OpenHighScore();
    [Button, DisableInEditorMode] public void ChangeMusicState() => SidePanel.ChangeMusicState();
    [Button, GUIColor(1, 0, 0), DisableInEditorMode] public void ExitGame() => MainPanel.ExitGame();
  }
}