using UnityEngine;

namespace Game.Application.Sound
{
  [RequireComponent(typeof(AudioSource))]
  public class SoundSource : MonoBehaviour
  {
    private AudioMediator _audioMediator;

    private void Awake()
    {
      _audioMediator = FindObjectOfType<AudioMediator>();
      _audioMediator.AddSound(this);
      TurnOn(_audioMediator.SoundOn);
    }

    private void OnDestroy() => 
      _audioMediator.RemoveSound(this);
    
    public void TurnOn(bool on) =>
      GetComponent<AudioSource>().mute = !on;
  }
}