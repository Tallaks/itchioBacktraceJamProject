using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
  public class SidePanel : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public Button MusicButton;

    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      MusicButton.onClick.AddListener(ChangeMusicState);
    }

    public void ChangeMusicState()
    {
    }
  }
}