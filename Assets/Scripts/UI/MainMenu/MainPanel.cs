using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
  public class MainPanel : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public Button StartGameButton;
    [Required, SceneObjectsOnly] public Button HighScoreButton;
    [Required, SceneObjectsOnly] public Button ExitButton;

    private void Awake()
    {
      StartGameButton.onClick.AddListener(StartGame);
      HighScoreButton.onClick.AddListener(OpenHighScore);
      ExitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
      Debug.Log("Start Game");
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