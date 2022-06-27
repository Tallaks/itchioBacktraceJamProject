using Game.Application.Sound;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MainMenu
{
  public class SidePanel : MonoBehaviour
  {
    [Required, SceneObjectsOnly] public Button MusicButton;
    [Required, SceneObjectsOnly] public Button SoundButton;
    private AudioMediator _audioMediator;

    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      MusicButton.onClick.AddListener(ChangeMusicState);
      SoundButton.onClick.AddListener(ChangeSoundState);

      _audioMediator = FindObjectOfType<AudioMediator>();
    }

    public void ChangeSoundState() => 
      _audioMediator.TurnOnSounds(SoundButton.GetComponent<OnOffButton>().IsOn);

    public void ChangeMusicState() => 
      _audioMediator.TurnOnMusic(MusicButton.GetComponent<OnOffButton>().IsOn);
  }
}